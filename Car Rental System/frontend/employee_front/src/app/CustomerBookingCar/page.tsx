'use client';

import { useState } from 'react';
import axios from 'axios';
import { useRouter } from 'next/navigation';
import { FaCheckCircle, FaTimesCircle, FaCar, FaUser, FaPhone, FaEnvelope, FaMapMarkerAlt,FaSignOutAlt } from 'react-icons/fa';
import toast, { Toaster } from 'react-hot-toast';

export default function CustomerBookingCarPage() {
  const router = useRouter();
  const [formData, setFormData] = useState({
    carId: '',
    customerName: '',
    customerEmail: '',
    customerPhoneNumber: '',
    pickupLocation: '',
    destinationLocation: '',
  });

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [activeMenu, setActiveMenu] = useState('CustomerBookingCar');

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
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

  const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  setLoading(true);
  setError('');

  try {
    const response = await axios.post('http://localhost:3001/booking/request', formData);
    
    toast.success('Booking confirmed successfully!', {
      duration: 3000,
      position: 'top-center',
      icon: <FaCheckCircle className="text-green-500" />,
    });

    setFormData({
      carId: '',
      customerName: '',
      customerEmail: '',
      customerPhoneNumber: '',
      pickupLocation: '',
      destinationLocation: '',
    });

  } catch (err) {
    
    if (axios.isAxiosError(err) && err.response?.status === 400) {
      setError(err.response?.data?.message || 'Validation error');
      toast.error(err.response?.data?.message || 'Validation error', {
        duration: 3000,
        position: 'top-center',
        icon: <FaTimesCircle className="text-red-500" />,
      });
    } 
    
    else {
      console.error('Booking submission error:', err);
      setError('An unexpected error occurred');
      toast.error('An unexpected error occurred', {
        duration: 3000,
        position: 'top-center',
        icon: <FaTimesCircle className="text-red-500" />,
      });
    }
  } finally {
    setLoading(false);
  }
};

  return (
    <div className="min-h-screen bg-gradient-to-br from-gray-900 to-gray-800 text-white">
      {/* Toast container */}
      <Toaster />
      
      <div className="flex h-full">
        {/* Sidebar */}
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

        {/* Main Content */}
        <main className="flex-1 overflow-auto p-8">
          <div className="max-w-2xl mx-auto">
            <div className="text-center mb-12">
              <h1 className="text-4xl font-bold mb-4 text-transparent bg-clip-text bg-gradient-to-r from-cyan-400 to-blue-500">
                Book Your Ride
              </h1>
            </div>

            {loading && (
              <div className="flex justify-center mb-6">
                <div className="animate-spin rounded-full h-10 w-10 border-t-2 border-b-2 border-cyan-500"></div>
              </div>
            )}
            
            {error && (
              <div className="mb-6 p-4 bg-red-900/50 border border-red-500 rounded-lg flex items-center gap-3">
                <FaTimesCircle className="text-red-400" />
                <span>{error}</span>
              </div>
            )}

            <form
              onSubmit={handleSubmit}
              className="bg-gray-800/50 backdrop-blur-sm p-8 rounded-2xl border border-gray-700 shadow-2xl space-y-6"
            >
              {/* Car ID Field */}
              <div className="space-y-2">
                <label htmlFor="carId" className="flex items-center gap-2 text-gray-300">
                  <FaCar className="text-cyan-400" /> Car ID
                </label>
                <input
                  type="text"
                  id="carId"
                  name="carId"
                  value={formData.carId}
                  onChange={handleChange}
                  className="w-full px-4 py-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500 focus:border-transparent transition"
                  placeholder="Enter car ID"
                  required
                />
              </div>

              {/* Customer Name Field */}
              <div className="space-y-2">
                <label htmlFor="customerName" className="flex items-center gap-2 text-gray-300">
                  <FaUser className="text-cyan-400" /> Full Name
                </label>
                <input
                  type="text"
                  id="customerName"
                  name="customerName"
                  value={formData.customerName}
                  onChange={handleChange}
                  className="w-full px-4 py-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500 focus:border-transparent transition"
                  placeholder="Your full name"
                  required
                />
              </div>

              {/* Email Field */}
              <div className="space-y-2">
                <label htmlFor="customerEmail" className="flex items-center gap-2 text-gray-300">
                  <FaEnvelope className="text-cyan-400" /> Email
                </label>
                <input
                  type="email"
                  id="customerEmail"
                  name="customerEmail"
                  value={formData.customerEmail}
                  onChange={handleChange}
                  className="w-full px-4 py-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500 focus:border-transparent transition"
                  placeholder="your.email@example.com"
                  required
                />
              </div>

              {/* Phone Number Field */}
              <div className="space-y-2">
                <label htmlFor="customerPhoneNumber" className="flex items-center gap-2 text-gray-300">
                  <FaPhone className="text-cyan-400" /> Phone Number
                </label>
                <input
                  type="text"
                  id="customerPhoneNumber"
                  name="customerPhoneNumber"
                  value={formData.customerPhoneNumber}
                  onChange={handleChange}
                  className="w-full px-4 py-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500 focus:border-transparent transition"
                  placeholder="+1 (123) 456-7890"
                  required
                />
              </div>

              {/* Location Fields */}
              <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                <div className="space-y-2">
                  <label htmlFor="pickupLocation" className="flex items-center gap-2 text-gray-300">
                    <FaMapMarkerAlt className="text-green-400" /> Pickup Location
                  </label>
                  <input
                    type="text"
                    id="pickupLocation"
                    name="pickupLocation"
                    value={formData.pickupLocation}
                    onChange={handleChange}
                    className="w-full px-4 py-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500 focus:border-transparent transition"
                    placeholder="Where to pick you up"
                    required
                  />
                </div>

                <div className="space-y-2">
                  <label htmlFor="destinationLocation" className="flex items-center gap-2 text-gray-300">
                    <FaMapMarkerAlt className="text-red-400" /> Destination
                  </label>
                  <input
                    type="text"
                    id="destinationLocation"
                    name="destinationLocation"
                    value={formData.destinationLocation}
                    onChange={handleChange}
                    className="w-full px-4 py-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500 focus:border-transparent transition"
                    placeholder="Your destination"
                    required
                  />
                </div>
              </div>

              <button
                type="submit"
                className={`w-full py-4 mt-6 text-lg font-semibold rounded-lg transition-all ${loading ? 
                  'bg-gray-600 cursor-not-allowed' : 
                  'bg-gradient-to-r from-cyan-600 to-blue-600 hover:from-cyan-500 hover:to-blue-500 shadow-lg hover:shadow-cyan-500/20'}`}
                disabled={loading}
              >
                {loading ? (
                  <span className="flex items-center justify-center gap-2">
                    <svg className="animate-spin h-5 w-5 text-white" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                      <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                      <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                    </svg>
                    Processing...
                  </span>
                ) : (
                  'Confirm Booking'
                )}
              </button>
            </form>
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