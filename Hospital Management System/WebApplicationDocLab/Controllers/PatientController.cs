﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApplicationDocLab.Context;
using WebApplicationDocLab.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;


namespace WebApplicationDocLab.Controllers
{
    public class PatientController : Controller
    {
        private DoctorLab _contextdb;
        private HttpClient _httpClient;

        public PatientController()
        {
            _contextdb = new DoctorLab();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"] ?? "http://localhost:64303/api/");
        }

        // GET: Patient Dashboard
        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null || Session["UserType"] == null || Session["UserType"].ToString() != "Patient")
            {
                return RedirectToAction("Login", "Login");
            }

            int patientId = (int)Session["UserId"];

            // Appointments
            var appointments = _contextdb.BookingAppointments
        .Where(x => x.PatientId == patientId)
        .Join(_contextdb.User_Infos,
            appointment => appointment.DoctorId,
            doctor => doctor.Id,
            (appointment, doctor) => new
            {
                Appointment = appointment,
                Doctor = doctor
            })
        .ToList()
        .Select(x => new BookingAppointment
        {
            Id = x.Appointment.Id,
            PatientId = x.Appointment.PatientId,
            DoctorId = x.Appointment.DoctorId,
            Booking_Date = x.Appointment.Booking_Date,
            ActualTime = x.Appointment.ActualTime,
            SerialNumber = x.Appointment.SerialNumber,
            BookType = x.Appointment.BookType,
            Created_at = x.Appointment.Created_at,
            User_Info = x.Doctor
        })
        .OrderByDescending(a => a.Booking_Date)
        .ToList();

            // Medical History
            var medicalHistory = _contextdb.Medical_Histories
                .Where(m => m.PatientId == patientId)
                .OrderByDescending(m => m.Created_at)
                .ToList();

            // Most recent prescription
            var recentPrescription = _contextdb.Prescriptions
                .Where(p => p.PatientId == patientId)
                .Include(p => p.Doctor_Details.User_Info)
                .Include(p => p.Doctor_Details)
                .Include(p => p.Doctor_Details.User_Info)

                .OrderByDescending(p => p.PrescriptionDate)
                .FirstOrDefault();

            var medicineList = new List<Medicine_List>();
            var testList = new List<Test_List>();

            if (recentPrescription != null)
            {
                medicineList = _contextdb.Medicine_Lists
                    .Where(m => m.PrescriptionId == recentPrescription.Id)
                    .Include(m => m.Medicine)
                    .ToList();

                testList = _contextdb.Test_Lists
                    .Where(t => t.PrescriptionId == recentPrescription.Id)
                    .Include(t => t.Test)
                    .ToList();
            }

            ViewBag.MedicineList = medicineList;
            ViewBag.TestList = testList;
            ViewBag.RecentPrescription = recentPrescription;
            ViewBag.Appointments = appointments;
            ViewBag.MedicalHistory = medicalHistory;

            return View();
        }


        [HttpGet]
        public ActionResult AddAppointment()
        {
            try
            {
                ViewBag.Doctors = _contextdb.User_Infos
                    .Where(u => u.UserType == "Doctor" && u.Status == "Active")
                    .ToList();

                ViewBag.DoctorDetails = _contextdb.Doctor_Details
                    .ToList();

                return View(new BookingAppointment());
            }
            catch (Exception ex)
            {
                // Log the error
                TempData["ErrorMessage"] = "Error loading appointment page: " + ex.Message;
                return RedirectToAction("Index", "Patient");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAppointment(BookingAppointment model)
        {
            try
            {
                // Validate required fields
                if (model.Booking_Date == default(DateTime))
                {
                    TempData["ErrorMessage"] = "Please select a valid appointment date.";
                    return RedirectToAction("AddAppointment");
                }
                if (string.IsNullOrEmpty(model.BookType))
                {
                    TempData["ErrorMessage"] = "Please select a booking type.";
                    return RedirectToAction("AddAppointment");
                }
                if (model.DoctorId == 0)
                {
                    TempData["ErrorMessage"] = "Please select a doctor.";
                    return RedirectToAction("AddAppointment");
                }

                // Check if the selected date is valid
                if (model.Booking_Date < DateTime.Today)
                {
                    TempData["ErrorMessage"] = "Cannot book appointments for past dates";
                    return RedirectToAction("AddAppointment");
                }

                // Get doctor's details
                var doctorDetails = _contextdb.Doctor_Details.FirstOrDefault(d => d.DoctorId == model.DoctorId);
                if (doctorDetails == null)
                {
                    TempData["ErrorMessage"] = "Doctor details not found";
                    return RedirectToAction("AddAppointment");
                }

                // Check if doctor is available on the selected day
                var selectedDay = model.Booking_Date.DayOfWeek.ToString();
                var availableDays = doctorDetails.Day.Split(',').Select(d => d.Trim());
                if (!availableDays.Contains(selectedDay))
                {
                    TempData["ErrorMessage"] = "Doctor is not available on the selected day";
                    return RedirectToAction("AddAppointment");
                }

                // Get all existing appointments for this doctor on this date
                var existingAppointments = _contextdb.BookingAppointments
                    .Where(a => a.DoctorId == model.DoctorId &&
                                DbFunctions.TruncateTime(a.Booking_Date) == model.Booking_Date.Date)
                    .OrderBy(a => a.SerialNumber)
                    .ToList();

                if (existingAppointments.Count >= 10)
                {
                    TempData["ErrorMessage"] = "Doctor already has maximum appointments for this day";
                    return RedirectToAction("AddAppointment");
                }

                // Assign serial number (next available)
                int nextSerial = existingAppointments.Count + 1;
                model.SerialNumber = nextSerial;

                // Calculate ActualTime based on doctor's start time and serial number
                // Each slot is 20 minutes
                TimeSpan startTime = TimeSpan.Parse(doctorDetails.TimeStart);
                TimeSpan slotTime = startTime.Add(TimeSpan.FromMinutes(20 * (nextSerial - 1)));

                // Check if slot is within doctor's working hours
                TimeSpan endTime = TimeSpan.Parse(doctorDetails.TimeEnd);
                if (slotTime < startTime || slotTime.Add(TimeSpan.FromMinutes(20)) > endTime)
                {
                    TempData["ErrorMessage"] = "No available time slot for this serial number within doctor's working hours.";
                    return RedirectToAction("AddAppointment");
                }

                model.ActualTime = slotTime;

                // Set additional fields
                model.PatientId = Convert.ToInt32(Session["UserId"]);
                model.Created_at = DateTime.Now;

                _contextdb.BookingAppointments.Add(model);
                _contextdb.SaveChanges();

                Session["AppointmentId"] = model.Id;
                Session["Amount"] = doctorDetails.ConsultingFees; // Assuming 'ConsultingFees' is the amount
                Session["PaymentMethod"] = model.BookType; // Assuming 'BookType' is the payment method (Online/Offline)

                TempData["SuccessMessage"] = $"Appointment booked successfully! Your serial number is {model.SerialNumber}. Your time slot is {slotTime:hh\\:mm} - {slotTime.Add(TimeSpan.FromMinutes(20)):hh\\:mm}.";

                return RedirectToAction("Payment");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error booking appointment: " + ex.Message;
                return RedirectToAction("AddAppointment");
            }
        }

        [HttpGet]
        public JsonResult GetExistingAppointments(int doctorId, string appointmentDate)
        {
            try
            {
                var date = DateTime.Parse(appointmentDate);
                var appointments = _contextdb.BookingAppointments
                    .Where(a => a.DoctorId == doctorId &&
                               DbFunctions.TruncateTime(a.Booking_Date) == date)
                    .Select(a => new {
                        ActualTime = a.ActualTime
                    })
                    .ToList();

                return Json(appointments, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Appointment/ViewAppointments
        public ActionResult ViewAppointments()
        {
            // Check if user is logged in
            if (Session["UserId"] == null || Session["UserType"].ToString() != "Patient")
            {
                return RedirectToAction("Login", "Login");
            }

            int patientId = Convert.ToInt32(Session["UserId"]);

            // Get appointments with doctor info and order by date (future appointments first)
            var appointments = _contextdb.BookingAppointments
                .Include(a => a.User_Info) // Eager load doctor data
                .Where(a => a.PatientId == patientId)
                .OrderBy(a => a.Booking_Date < DateTime.Today) // Past appointments last
                .ThenBy(a => a.Booking_Date) // Then by date
                .ThenBy(a => a.ActualTime)    // Then by time
                .ToList();

            return View(appointments);
        }

        // POST: Cancel Appointment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelAppointment(int Id)
        {
            var appointment = _contextdb.BookingAppointments.Find(Id);

            if (appointment != null)
            {
                _contextdb.BookingAppointments.Remove(appointment);
                _contextdb.SaveChanges();
                TempData["Message"] = "Appointment deleted successfully";
            }
            else
            {
                TempData["Error"] = "Appointment not found";
            }

            return RedirectToAction("ViewAppointments", "Patient");
        }

        [HttpGet]
        public ActionResult EditAppointment(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var appointment = _contextdb.BookingAppointments.Find(id);
            if (appointment == null || appointment.PatientId != Convert.ToInt32(Session["UserId"]))
            {
                return HttpNotFound();
            }

            // Get available doctors
            var doctors = _contextdb.User_Infos
                .Where(u => u.UserType == "Doctor")
                .AsEnumerable()
                .Select(d => new {
                    d.Id,
                    FullName = $"{d.Title} {d.FirstName} {d.LastName}"
                })
                .ToList();

            ViewBag.Doctors = new SelectList(doctors, "Id", "FullName", appointment.DoctorId);
            ViewBag.BookTypes = new SelectList(Enum.GetValues(typeof(BookType)).Cast<BookType>(), appointment.BookType);

            return View("AddAppointment", appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppointment(BookingAppointment appointment)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingAppointment = _contextdb.BookingAppointments.Find(appointment.Id);
                    if (existingAppointment == null || existingAppointment.PatientId != Convert.ToInt32(Session["UserId"]))
                    {
                        return HttpNotFound();
                    }

                    // Update only the fields that should be editable
                    existingAppointment.DoctorId = appointment.DoctorId;
                    existingAppointment.Booking_Date = appointment.Booking_Date;
                    existingAppointment.BookType = appointment.BookType;

                    _contextdb.SaveChanges();

                    TempData["SuccessMessage"] = "Appointment updated successfully!";
                    return RedirectToAction("ViewAppointments");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error updating appointment: " + ex.Message);
                }
            }

            // Repopulate dropdowns if validation fails
            var doctors = _contextdb.User_Infos
                .Where(u => u.UserType == "Doctor")
                .AsEnumerable()
                .Select(d => new {
                    d.Id,
                    FullName = $"{d.Title} {d.FirstName} {d.LastName}"
                })
                .ToList();

            ViewBag.Doctors = new SelectList(doctors, "Id", "FullName", appointment.DoctorId);
            ViewBag.BookTypes = new SelectList(Enum.GetValues(typeof(BookType)).Cast<BookType>(), appointment.BookType);

            return View("AddAppointment", appointment);
        }

        // GET: Medical Records
        public ActionResult MedicalRecords()
        {
            if (Session["UserId"] == null || Session["UserType"].ToString() != "Patient" || Session["Status"].ToString() != "Active")
            {
                return RedirectToAction("Login", "Login");
            }

            int patientId = (int)Session["UserId"];
            var medicalHistory = _contextdb.Medical_Histories.FirstOrDefault(m => m.PatientId == patientId);

            ViewBag.HasRecord = medicalHistory != null;

            // Populate Enum dropdown list
            ViewBag.RecordTypeList = Enum.GetValues(typeof(RecordType))
                .Cast<RecordType>()
                .Select(e => new SelectListItem
                {
                    Text = e.ToString(),
                    Value = e.ToString()
                }).ToList();

            return View(medicalHistory ?? new Medical_History());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMedicalHistory(Medical_History model)
        {
            // Ensure the patient is logged in
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Ensure the model is valid
            if (ModelState.IsValid)
            {
                try
                {
                    model.PatientId = (int)Session["UserId"]; // Set the logged-in patient's ID
                    model.Created_at = DateTime.Now; // Set the created timestamp

                    // Get all selected record types and join them with commas
                    var selectedRecordTypes = Request.Form.GetValues("Record_Type");
                    if (selectedRecordTypes != null && selectedRecordTypes.Length > 0)
                    {
                        model.Record_Type = string.Join(", ", selectedRecordTypes);
                    }
                    else
                    {
                        model.Record_Type = string.Empty;
                    }

                    _contextdb.Medical_Histories.Add(model);
                    _contextdb.SaveChanges();

                    TempData["SuccessMessage"] = "Medical history saved successfully!";
                    return RedirectToAction("MedicalRecords");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error saving medical history: " + ex.Message);
                }
            }

            // Return the form with validation errors if the model state is invalid
            return View("MedicalRecords", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult UpdateMedicalHistory(Medical_History model)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            // Get the patient ID first before using it in LINQ
            int patientId = (int)Session["UserId"];

            if (ModelState.IsValid)
            {
                try
                {
                    // First get the patient ID
                    var existingRecord = _contextdb.Medical_Histories
                        .FirstOrDefault(m => m.Id == model.Id && m.PatientId == patientId);

                    if (existingRecord == null)
                    {
                        TempData["ErrorMessage"] = "Record not found or you don't have permission to edit it.";
                        return RedirectToAction("MedicalRecords");
                    }

                    // Update the record types from the form
                    var selectedRecordTypes = Request.Form.GetValues("Record_Type");
                    existingRecord.Record_Type = selectedRecordTypes != null ?
                        string.Join(", ", selectedRecordTypes) :
                        string.Empty;

                    existingRecord.Description = model.Description;
                    existingRecord.Created_at = DateTime.Now;

                    _contextdb.SaveChanges();

                    TempData["SuccessMessage"] = "Medical history updated successfully!";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Error updating medical history: " + ex.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Please correct the errors in the form.";
            }

            return RedirectToAction("MedicalRecords");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMedicalHistory(int id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var record = _contextdb.Medical_Histories.FirstOrDefault(m =>
                m.Id == id && m.PatientId == (int)Session["UserId"]);

            if (record == null)
            {
                TempData["ErrorMessage"] = "Record not found or you don't have permission to delete it.";
            }
            else
            {
                _contextdb.Medical_Histories.Remove(record);
                _contextdb.SaveChanges();
                TempData["SuccessMessage"] = "Medical history deleted successfully!";
            }

            return RedirectToAction("MedicalRecords");
        }

        // GET: Visit History
        public ActionResult VisitHistory()
        {
            // Ensure the patient is logged in
            if (Session["UserEmail"] == null || Session["UserType"].ToString() != "Patient" || Session["Status"].ToString() != "Active")
            {
                return RedirectToAction("Login", "Login");
            }

            // Get the current patient's Id from session
            var patientId = (int)Session["UserId"];

            // Get the patient's visit history
            var visits = _contextdb.BookingAppointments.Where(x => x.PatientId == patientId).ToList();
            ViewBag.VisitHistory = visits;
            return View();
        }
        public ActionResult Prescriptions()
        {
            // Ensure the patient is logged in
            if (Session["UserEmail"] == null || Session["UserType"].ToString() != "Patient" || Session["Status"].ToString() != "Active")
            {
                return RedirectToAction("Login", "Login");
            }

            // Get the current patient's Id from session
            int patientId = (int)Session["UserId"];

            // Get the most recent prescription for the patient, including Doctor_Details and Medicine
            var recentPrescription = _contextdb.Prescriptions
                .Where(x => x.PatientId == patientId)
                .Include(x => x.Doctor_Details)  // Eager load the Doctor_Details
                .Include(x => x.Medicine)        // Eager load the Medicine
                .OrderByDescending(x => x.PrescriptionDate)  // Sort by PrescriptionDate descending
                .FirstOrDefault();  // Get the most recent one

            // Pass the most recent prescription to the view
            ViewBag.RecentPrescription = recentPrescription;

            return View(recentPrescription);
        }

        // GET: Previous Prescriptions (excluding the most recent one)
        public ActionResult PreviousPrescriptions()
        {
            // Check if session contains the UserId
            if (Session["UserId"] == null)
            {
                // Redirect to login page if the user is not logged in
                return RedirectToAction("Login", "Login");
            }

            // Get the current patient's Id from session
            int patientId = (int)Session["UserId"];

            // Get the most recent prescription to exclude it from the list
            var recentPrescription = _contextdb.Prescriptions
                .Where(x => x.PatientId == patientId)
                .OrderByDescending(x => x.PrescriptionDate)
                .FirstOrDefault();

            // Get all previous prescriptions, excluding the most recent one
            var previousPrescriptions = _contextdb.Prescriptions
                .Where(x => x.PatientId == patientId && x.PrescriptionDate != recentPrescription.PrescriptionDate)
                .Include(x => x.Doctor_Details)  // Eagerly load Doctor_Details
                .Include(x => x.Medicine)        // Eagerly load Medicine
                .OrderByDescending(x => x.PrescriptionDate)  // Sort by PrescriptionDate descending
                .ToList();  // Execute the query

            // Pass the list of previous prescriptions to the view
            return View(previousPrescriptions);
        }

        [HttpGet]
        public ActionResult Payment()
        {
            try
            {
                if (Session["AppointmentId"] == null || Session["Amount"] == null || Session["PaymentMethod"] == null)
                {
                    TempData["ErrorMessage"] = "Missing session data. Please try again.";
                    return RedirectToAction("AddAppointment");
                }

                // Check if payment already exists for this appointment
                int appointmentId = Convert.ToInt32(Session["AppointmentId"]);
                var existingPayment = _contextdb.Payments.FirstOrDefault(p => p.AppointmentId == appointmentId);

                if (existingPayment != null)
                {
                    // If payment exists, show the existing payment status
                    ViewBag.PaymentStatus = existingPayment.Status;
                    ViewBag.PaymentAmount = existingPayment.Amount.ToString("0.00");
                    ViewBag.AvailablePaymentMethods = new List<string> { existingPayment.PaymentMethod };
                    return View(existingPayment);
                }

                string transactionId = "TXN-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" +
                                     Guid.NewGuid().ToString().Substring(0, 4).ToUpper();

                var payment = new Payment
                {
                    TransactionId = transactionId,
                    Amount = Convert.ToDecimal(Session["Amount"]),
                    PaymentMethod = Session["PaymentMethod"].ToString(),
                    AppointmentId = appointmentId,
                    Status = "Pending" // Set initial status as Pending
                };

                ViewBag.PaymentAmount = payment.Amount.ToString("0.00");
                ViewBag.PaymentStatus = payment.Status;

                ViewBag.AvailablePaymentMethods = payment.PaymentMethod == "Online"
                    ? new List<string> { "Card", "Bkash", "Rocket", "Nagad", "OnlineBanking" }
                    : new List<string> { "Cash" };

                return View(payment);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error processing payment: " + ex.Message;
                return RedirectToAction("AddAppointment");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(Payment payment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Process payment
                    payment.Created_at = DateTime.Now;
                    payment.Status = "Completed";
                    _contextdb.Payments.Add(payment);
                    _contextdb.SaveChanges();

                    // Clear session
                    Session.Remove("AppointmentId");
                    Session.Remove("Amount");
                    Session.Remove("PaymentMethod");

                    // Redirect directly to PaymentHistory
                    TempData["SuccessMessage"] = "Payment completed successfully!";
                    return RedirectToAction("PaymentHistory");
                }

                // If model is invalid, return to view with errors
                ViewBag.PaymentAmount = payment.Amount.ToString("0.00");
                ViewBag.AvailablePaymentMethods = payment.PaymentMethod == "Online"
                    ? new List<string> { "Card", "Bkash", "Rocket", "Nagad", "OnlineBanking" }
                    : new List<string> { "Cash" };

                return View(payment);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error processing payment: " + ex.Message;
                return RedirectToAction("Payment");
            }
        }





        private byte[] GenerateReceiptPdf(Payment payment)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                document.Open();

                // Add title
                Paragraph title = new Paragraph("PAYMENT RECEIPT",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20;
                document.Add(title);

                // Fetch related appointment and user info
                var appointment = _contextdb.BookingAppointments
                    .Include("User_Info")
                    .FirstOrDefault(a => a.Id == payment.AppointmentId);

                // Fetch patient info
                User_Info patientInfo = null;
                if (appointment != null)
                {
                    patientInfo = _contextdb.User_Infos.FirstOrDefault(u => u.Id == appointment.PatientId);
                }
                User_Info DoctorInfo = null;
                if (appointment != null)
                {
                    DoctorInfo = _contextdb.User_Infos.FirstOrDefault(u => u.Id == appointment.DoctorId);
                }
                // Create table
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 40, 60 });

                // Add receipt data
                AddPdfCell(table, "Transaction ID:", true);
                AddPdfCell(table, payment.TransactionId);

                AddPdfCell(table, "Date:", true);
                AddPdfCell(table, payment.Created_at.ToString("dd MMM yyyy hh:mm tt"));

                AddPdfCell(table, "Appointment ID:", true);
                AddPdfCell(table, payment.AppointmentId.ToString());

                // --- Additional BookingAppointment fields ---
                if (appointment != null)
                {
                    // Doctor Name
                    // Patient Name
                    string DoctorName = DoctorInfo != null
                        ? $"{DoctorInfo.Title} {DoctorInfo.FirstName} {DoctorInfo.LastName}"
                        : "N/A";
                    AddPdfCell(table, "Patient Name:", true);
                    AddPdfCell(table, DoctorName);

                    // Patient Name
                    string patientName = patientInfo != null
                        ? $"{patientInfo.Title} {patientInfo.FirstName} {patientInfo.LastName}"
                        : "N/A";
                    AddPdfCell(table, "Patient Name:", true);
                    AddPdfCell(table, patientName);

                    // Serial Number
                    AddPdfCell(table, "Serial Number:", true);
                    AddPdfCell(table, appointment.SerialNumber.ToString());

                    // Booking Type
                    AddPdfCell(table, "Booking Type:", true);
                    AddPdfCell(table, appointment.BookType ?? "N/A");

                    // Actual Time
                    AddPdfCell(table, "Actual Time:", true);
                    AddPdfCell(table, appointment.ActualTime.ToString(@"hh\:mm"));

                    // Booking Date
                    AddPdfCell(table, "Booking Date:", true);
                    AddPdfCell(table, appointment.Booking_Date.ToString("dd MMM yyyy"));
                }
                // --- End additional fields ---

                AddPdfCell(table, "Payment Method:", true);
                AddPdfCell(table, payment.PaymentMethod);

                AddPdfCell(table, "Amount:", true);
                AddPdfCell(table, payment.Amount.ToString("0.00") + " BDT");

                AddPdfCell(table, "Status:", true);
                AddPdfCell(table, payment.Status);

                document.Add(table);

                // Thank you message
                Paragraph thanks = new Paragraph("\n\nThank you for your payment!",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12));
                thanks.Alignment = Element.ALIGN_CENTER;
                document.Add(thanks);

                document.Close();
                return ms.ToArray();
            }
        }

        private void AddPdfCell(PdfPTable table, string text, bool isHeader = false)
        {
            var font = isHeader
                ? FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)
                : FontFactory.GetFont(FontFactory.HELVETICA, 12);

            var cell = new PdfPCell(new Phrase(text, font));
            cell.BorderWidth = 0.75f;
            cell.Padding = 5;
            table.AddCell(cell);
        }

        // GET: Payment History
        public ActionResult PaymentHistory()
        {
            // Ensure the patient is logged in
            if (Session["UserId"] == null || Session["UserType"].ToString() != "Patient")
            {
                return RedirectToAction("Login", "Login");
            }

            int patientId = Convert.ToInt32(Session["UserId"]);

            // Get all appointments for this patient
            var patientAppointmentIds = _contextdb.BookingAppointments
                .Where(a => a.PatientId == patientId)
                .Select(a => a.Id)
                .ToList();

            // Get payment history for these appointments
            var paymentHistory = _contextdb.Payments
                .Where(p => patientAppointmentIds.Contains(p.AppointmentId))
                .OrderByDescending(p => p.Created_at)
                .ToList();

            return View(paymentHistory);
        }



        public ActionResult DownloadReceipt(int id)
        {
            var payment = _contextdb.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }

            // Check if the payment belongs to the logged-in patient
            var appointment = _contextdb.BookingAppointments.Find(payment.AppointmentId);
            if (appointment == null || appointment.PatientId != Convert.ToInt32(Session["UserId"]))
            {
                return new HttpUnauthorizedResult();
            }

            byte[] pdfBytes = GenerateReceiptPdf(payment);
            return File(pdfBytes, "application/pdf", $"Receipt_{payment.TransactionId}.pdf");
        }

        public ActionResult Profile()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Login");

            int userId = (int)Session["UserId"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64303/api/");
                var response = client.GetAsync($"Profile/{userId}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var profile = response.Content.ReadAsAsync<User_Info>().Result;
                    return View(profile);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(new User_Info());
                }
            }
        }

        // GET: Patient/EditProfile
        public ActionResult EditProfile()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Login");

            int userId = (int)Session["UserId"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64303/api/");
                var response = client.GetAsync($"Profile/{userId}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var profile = response.Content.ReadAsAsync<User_Info>().Result;
                    return View(profile);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(new User_Info());
                }
            }
        }

        // POST: Patient/EditProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProfile(User_Info profile)
        {

            // 1. First validate only the fields we want to update
            if (string.IsNullOrEmpty(profile.FirstName))
                ModelState.AddModelError("FirstName", "First name is required");

            if (string.IsNullOrEmpty(profile.LastName))
                ModelState.AddModelError("LastName", "Last name is required");

            if (string.IsNullOrEmpty(profile.Phone))
                ModelState.AddModelError("Phone", "Phone is required");

            if (string.IsNullOrEmpty(profile.Address))
                ModelState.AddModelError("Address", "Address is required");

            if (profile.DateOfBirth == default(DateTime) ||
                profile.DateOfBirth < new DateTime(1900, 1, 1) ||
                profile.DateOfBirth > new DateTime(2100, 12, 31))
            {
                ModelState.AddModelError("DateOfBirth", "Valid date of birth is required");
            }

            // 2. Remove validation for fields we're not updating
            ModelState.Remove("Email");
            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("UserType");
            ModelState.Remove("Status");

            if (!ModelState.IsValid)
            {
                return View(profile);
            }

            try
            {
                int userId = (int)Session["UserId"];

                // 3. Get existing profile from database
                var existingProfile = _contextdb.User_Infos.Find(userId);
                if (existingProfile == null)
                {
                    TempData["ErrorMessage"] = "Profile not found";
                    return RedirectToAction("Profile");
                }

                // 4. Update only the allowed fields
                existingProfile.FirstName = profile.FirstName;
                existingProfile.LastName = profile.LastName;
                existingProfile.Phone = profile.Phone;
                existingProfile.Address = profile.Address;
                existingProfile.DateOfBirth = profile.DateOfBirth;
                existingProfile.Gender = profile.Gender;
                existingProfile.BloodGroup = profile.BloodGroup;
                existingProfile.Title = profile.Title;
                existingProfile.NID = profile.NID;

                // 5. Save changes
                _contextdb.SaveChanges();

                TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToAction("Profile");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View(profile);
            }
        }

        // GET: Patient/DeleteProfile
        public ActionResult DeleteProfile()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Login");

            int userId = (int)Session["UserId"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64303/api/");
                var response = client.GetAsync($"Profile/{userId}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var profile = response.Content.ReadAsAsync<User_Info>().Result;
                    return View(profile);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(new User_Info());
                }
            }
        }

        // POST: Patient/DeleteProfile
        [HttpPost, ActionName("DeleteProfile")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteProfileConfirmed()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Login");

            try
            {
                int userId = (int)Session["UserId"];

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:64303/api/");
                    // Change this line to use "Profile" instead of "ProfileDelete"
                    var response = await client.DeleteAsync($"Profile/{userId}");

                    if (response.IsSuccessStatusCode)
                    {
                        Session.Clear(); // Clear the session
                        TempData["SuccessMessage"] = "Your profile has been deleted successfully.";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        TempData["ErrorMessage"] = $"Failed to delete profile: {errorContent}";
                        return RedirectToAction("Profile");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return RedirectToAction("Profile");
            }
        }

        // GET: Logout
        public ActionResult Logout()
        {
            Session.Clear();  // Clear the session
            return RedirectToAction("Login", "Login");
        }
    }
}
