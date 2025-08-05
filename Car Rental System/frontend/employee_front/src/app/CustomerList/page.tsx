'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import axios from 'axios';
import { FaUser, FaEnvelope, FaPhone, FaMapMarkerAlt, FaSignOutAlt } from 'react-icons/fa';
import { jsPDF } from 'jspdf';
import toast, { Toaster } from 'react-hot-toast';

interface Customer {
  id: number;
  carId: number;
  customerName: string;
  customerEmail: string;
  pickupLocation: string;
  destinationLocation: string;
  distance: number;
  price: number;
  customerPhoneNumber: string;
  status: string;
}

export default function CustomerListPage() {
  const router = useRouter();
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [activeMenu, setActiveMenu] = useState('CustomerList');

  const generateCustomerPdf = (customer: Customer) => {
    const pdfDoc = new jsPDF();
    
    
    pdfDoc.setFontSize(20);
    pdfDoc.setTextColor(40, 53, 147);
    pdfDoc.text('RideXPress - Customer Receipt', 105, 20, { align: 'center' });
    
   
    pdfDoc.setFontSize(12);
    pdfDoc.setTextColor(0, 0, 0);
    
    let yPosition = 40;
    
    
    pdfDoc.setFont('helvetica', 'bold');
    pdfDoc.text('Customer Information:', 14, yPosition);
    pdfDoc.setFont('helvetica', 'normal');
    
    yPosition += 10;
    pdfDoc.text(`Name: ${customer.customerName}`, 14, yPosition);
    yPosition += 8;
    pdfDoc.text(`Email: ${customer.customerEmail}`, 14, yPosition);
    yPosition += 8;
    pdfDoc.text(`Phone: ${customer.customerPhoneNumber}`, 14, yPosition);
    
    
    yPosition += 15;
    pdfDoc.setFont('helvetica', 'bold');
    pdfDoc.text('Trip Details:', 14, yPosition);
    pdfDoc.setFont('helvetica', 'normal');
    
    yPosition += 10;
    pdfDoc.text(`Pickup: ${customer.pickupLocation}`, 14, yPosition);
    yPosition += 8;
    pdfDoc.text(`Destination: ${customer.destinationLocation}`, 14, yPosition);
    
    
    yPosition += 15;
    pdfDoc.setFont('helvetica', 'bold');
    pdfDoc.text('Pricing:', 14, yPosition);
    pdfDoc.setFont('helvetica', 'normal');
    
    yPosition += 10;
    pdfDoc.text(`Distance: ${customer.distance} km`, 14, yPosition);
    yPosition += 8;
    pdfDoc.text(`Price: $${customer.price}`, 14, yPosition);
    
    
    yPosition += 20;
    pdfDoc.setFontSize(10);
    pdfDoc.setTextColor(100, 100, 100);
    pdfDoc.text('Thank you for choosing RideXPress!', 105, yPosition, { align: 'center' });
    
    
    pdfDoc.save(`customer-receipt-${customer.id}.pdf`);
  };

  const fetchCustomers = async () => {
    const token = sessionStorage.getItem('token');
    if (!token) {
      setError('Unauthorized: Token missing');
      setLoading(false);
      return;
    }

    try {
      const res = await axios.get('http://localhost:3001/booking/showall', {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      const acceptedCustomers = res.data.filter((customer: Customer) => customer.status === 'Accepted');
      setCustomers(acceptedCustomers);
    } catch (err: any) {
      console.error('Error fetching customers:', err);
      setError('Could not load customer data');
      toast.error('Could not load customer data', {
        position: 'top-center',
      });
    } finally {
      setLoading(false);
    }
  };

  const handleLogout = async () => {
    const token = sessionStorage.getItem('token');
    if (!token) {
      toast.error('No active session found');
      return;
    }

    try {
      await axios.post('http://localhost:3001/authentication/logout', {}, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });

      sessionStorage.removeItem('token');
      sessionStorage.removeItem('email');
      toast.success('Logged out successfully', {
        position: 'top-center',
      });
      router.push('/login');
    } catch (err) {
      console.error('Logout failed:', err);
      toast.error('Logout failed. Please try again.', {
        position: 'top-center',
      });
    }
  };

  useEffect(() => {
    fetchCustomers();
  }, []);

  return (
    <div className="min-h-screen bg-gradient-to-br from-gray-900 to-gray-800 text-white">
      <Toaster />
      
      <div className="flex h-full">
        <aside className="w-64 bg-gray-800/80 backdrop-blur-lg p-6 space-y-8 border-r border-gray-700">
          <h2 className="text-2xl font-bold text-transparent bg-clip-text bg-gradient-to-r from-cyan-400 to-blue-500">
            RideXPress
          </h2>
          <ul className="space-y-3">
            {['Dashboard', 'CustomerList', 'RequestHistory', 'PendingRequests', 'profile', 'CustomerBookingCar'].map((item) => (
              <li key={item}>
                <button
                  className={`w-full text-left px-4 py-3 rounded-lg transition-all ${activeMenu === item ? 
                    'bg-gradient-to-r from-blue-600 to-cyan-500 text-white shadow-lg' : 
                    'text-gray-300 hover:bg-gray-700/50 hover:text-white'}`}
                  onClick={() => { setActiveMenu(item); router.push(`/${item}`); }}
                >
                  {item.replace(/([A-Z])/g, ' $1').trim()}
                </button>
              </li>
            ))}
          </ul>
          <button 
            onClick={handleLogout}
            className="w-full mt-12 px-4 py-3 bg-red-600/90 hover:bg-red-500 text-white rounded-lg transition-all flex items-center justify-center gap-2"
          >
            <FaSignOutAlt /> Logout
          </button>
        </aside>

        <main className="flex-1 overflow-auto p-8">
          <div className="max-w-7xl mx-auto">
            <div className="text-center mb-12">
              <h1 className="text-4xl font-bold mb-4 text-transparent bg-clip-text bg-gradient-to-r from-cyan-400 to-blue-500">
                 Customer List
              </h1>
              
            </div>

            {loading && (
              <div className="flex justify-center mb-6">
                <div className="animate-spin rounded-full h-10 w-10 border-t-2 border-b-2 border-cyan-500"></div>
              </div>
            )}
            
            {error && (
              <div className="mb-6 p-4 bg-red-900/50 border border-red-500 rounded-lg flex items-center gap-3">
                <span>{error}</span>
              </div>
            )}

            {!loading && !error && (
              <div className="grid grid-cols-1 lg:grid-cols-2 xl:grid-cols-3 gap-6">
                {customers.map((customer) => (
                  <div 
                    key={customer.id} 
                    className="bg-gray-800/50 backdrop-blur-sm rounded-xl p-6 border border-cyan-500/30 shadow-xl hover:shadow-2xl transition-all"
                  >
                    <div className="space-y-4">
                      <div className="flex items-start gap-4">
                        <div className="bg-cyan-500/10 p-3 rounded-full">
                          <FaUser className="text-cyan-400 text-xl" />
                        </div>
                        <div>
                          <h3 className="text-xl font-semibold">{customer.customerName}</h3>
                          <p className="text-gray-400">{customer.customerEmail}</p>
                          <p className="text-gray-400 flex items-center gap-1 mt-1">
                            <FaPhone className="text-sm" /> {customer.customerPhoneNumber}
                          </p>
                        </div>
                      </div>

                      <div className="space-y-2">
                        <div className="flex items-center gap-2">
                          <FaMapMarkerAlt className="text-green-400 flex-shrink-0" />
                          <p className="text-gray-300">{customer.pickupLocation}</p>
                        </div>
                        <div className="flex items-center gap-2">
                          <FaMapMarkerAlt className="text-red-400 flex-shrink-0" />
                          <p className="text-gray-300">{customer.destinationLocation}</p>
                        </div>
                      </div>

                      <div className="grid grid-cols-2 gap-4 pt-2">
                        <div>
                          <p className="text-gray-400 text-sm">Distance</p>
                          <p className="font-medium">{customer.distance} km</p>
                        </div>
                        <div>
                          <p className="text-gray-400 text-sm">Price</p>
                          <p className="font-medium">${customer.price}</p>
                        </div>
                      </div>

                      <div className="pt-4">
                        <button
                          onClick={() => generateCustomerPdf(customer)}
                          className="w-full flex items-center justify-center gap-2 px-4 py-2 bg-gradient-to-r from-blue-600 to-cyan-600 hover:from-blue-500 hover:to-cyan-500 rounded-lg transition-all"
                        >
                          <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M17 17h2a2 2 0 002-2v-4a2 2 0 00-2-2H5a2 2 0 00-2 2v4a2 2 0 002 2h2m2 4h6a2 2 0 002-2v-4a2 2 0 00-2-2H9a2 2 0 00-2 2v4a2 2 0 002 2zm8-12V5a2 2 0 00-2-2H9a2 2 0 00-2 2v4h10z" />
                          </svg>
                          Print Receipt
                        </button>
                      </div>
                    </div>
                  </div>
                ))}
              </div>
            )}

            {!loading && !error && customers.length === 0 && (
              <div className="text-center py-12">
                <p className="text-xl text-gray-400">No active customers found</p>
              </div>
            )}
          </div>

          <footer className="footer sm:footer-horizontal bg-base-200 text-base-content p-10">
            <aside>
              <svg
                width="50"
                height="50"
                viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg"
                fillRule="evenodd"
                clipRule="evenodd"
                className="fill-current">
                <path
                  d="M22.672 15.226l-2.432.811.841 2.515c.33 1.019-.209 2.127-1.23 2.456-1.15.325-2.148-.321-2.463-1.226l-.84-2.518-5.013 1.677.84 2.517c.391 1.203-.434 2.542-1.831 2.542-.88 0-1.601-.564-1.86-1.314l-.842-2.516-2.431.809c-1.135.328-2.145-.317-2.463-1.229-.329-1.018.211-2.127 1.231-2.456l2.432-.809-1.621-4.823-2.432.808c-1.355.384-2.558-.59-2.558-1.839 0-.817.509-1.582 1.327-1.846l2.433-.809-.842-2.515c-.33-1.02.211-2.129 1.232-2.458 1.02-.329 2.13.209 2.461 1.229l.842 2.515 5.011-1.677-.839-2.517c-.403-1.238.484-2.553 1.843-2.553.819 0 1.585.509 1.85 1.326l.841 2.517 2.431-.81c1.02-.33 2.131.211 2.461 1.229.332 1.018-.21 2.126-1.23 2.456l-2.433.809 1.622 4.823 2.433-.809c1.242-.401 2.557.484 2.557 1.838 0 .819-.51 1.583-1.328 1.847m-8.992-6.428l-5.01 1.675 1.619 4.828 5.011-1.674-1.62-4.829z"></path>
              </svg>
              <p>
                      RideXPress Industries Ltd.
                <br />
                Providing reliable tech since 1992
              </p>
            </aside>
            <nav>
              <h6 className="footer-title">Services</h6>
              <a className="link link-hover">Branding</a>
              <a className="link link-hover">Design</a>
              <a className="link link-hover">Marketing</a>
              <a className="link link-hover">Advertisement</a>
            </nav>
            <nav>
              <h6 className="footer-title">Company</h6>
              <a className="link link-hover">About us</a>
              <a className="link link-hover">Contact</a>
              <a className="link link-hover">Jobs</a>
              <a className="link link-hover">Press kit</a>
            </nav>
            <nav>
              <h6 className="footer-title">Legal</h6>
              <a className="link link-hover">Terms of use</a>
              <a className="link link-hover">Privacy policy</a>
              <a className="link link-hover">Cookie policy</a>
            </nav>
          </footer>
        </main>
      </div>
    </div>
  );
}