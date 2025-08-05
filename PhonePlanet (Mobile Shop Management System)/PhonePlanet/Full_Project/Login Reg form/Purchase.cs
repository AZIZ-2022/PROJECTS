using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login_Reg_form
{
    public partial class Purchase : Form
    {
        public string uname { get; set; }
        public string Phone_No { get; set; }
        public string Address { get; set; }


        public string Company_Name { get; set; }
        public string Model_Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }

        public Purchase()
        {
            InitializeComponent();
            user_name_label_c.Text = Login.uname;

            company_name_label_c.Text = Available_Phones.Company_Name;
            model_name_label_c.Text = Available_Phones.Model_Name;
            quantity_label_c.Text = Available_Phones.Quantity;
            price_label_c.Text = Available_Phones.Price;
        }
        private int loggedInCustomerID;
        SqlConnection con = new SqlConnection("Data Source=TAWSIF-AZIZ-AHM\\SQLEXPRESS;Initial Catalog=PhonePlanetDB;Integrated Security=True");




        private void button1_Click(object sender, EventArgs e)
        {
            Available_Phones f3 = new Available_Phones();
            f3.Show();
            this.Hide();
        }
        Bitmap bmp;
        private void Purchase_button_Click(object sender, EventArgs e)
        {
            string query = "insert into Add_to_Cart values ('" + user_name_label_c.Text + "','" + phone_label_c.Text + "','" + address_label_c.Text + "','" + company_name_label_c.Text + "','" + model_name_label_c.Text + "','" + Convert.ToInt32(quantity_label_c.Text) + "','" + price_label_c.Text + "','" + discounttb.Text + "','" + totalamounttb.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            if (con.State == ConnectionState.Open)
            {

                int result = cmd.ExecuteNonQuery();//query execute

                
                con.Close();
            }

            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();

            //Receipt f8 = new Receipt();
            //f8.Show();
            //this.Hide();
        }

        private void Purchase_Load(object sender, EventArgs e)
        {

            int q = Convert.ToInt32(quantity_label_c.Text);
            float price = float.Parse(price_label_c.Text);
            price_label_c.Text = (q * price).ToString();
            con.Open();
            string query = "select Mobile_No,Address from Approved_Customer where User_Name='" + user_name_label_c.Text + "'";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("User_Name", loggedInCustomerID);

              
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {


                    phone_label_c.Text = reader["Mobile_No"].ToString();
                    address_label_c.Text = reader["Address"].ToString();





                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }

                reader.Close();
                con.Close();
            }
            string query2 = "SELECT SUM(Quantity) FROM Add_to_Cart WHERE User_Name='" + user_name_label_c.Text + "'";
            DataTable dt = new DataTable();

            using (SqlDataAdapter sda = new SqlDataAdapter(query2, con))
            {
                sda.Fill(dt);
            }

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                decimal amount = Convert.ToDecimal(dt.Rows[0][0]);
                amount.ToString("0.0"); // Format amount with two decimal places
                if (amount >= 3)
                {
                    discounttb.Text = "20%";
                    totalamounttb.Text = (Convert.ToInt32(price_label_c.Text)-(0.2 * Convert.ToInt32(price_label_c.Text))).ToString();
                }
                else
                {
                    discounttb.Text = "Not eligible";
                    totalamounttb.Text = (1 * Convert.ToInt32(price_label_c.Text)).ToString();
                }
            }
            else
            {
                discounttb.Text = "0.00"; // If no amount found, display zero
                totalamounttb.Text = (1 * Convert.ToInt32(price_label_c.Text)).ToString();
            }







        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Homepage C = new Customer_Homepage();
            C.Show();
            this.Hide();
        }
    }
    }

