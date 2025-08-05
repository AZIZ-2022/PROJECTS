'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import axios from 'axios';
import { FaCheck, FaTimes, FaUser, FaEnvelope, FaMapMarkerAlt, FaRoute,FaSignOutAlt } from 'react-icons/fa';
import toast, { Toaster } from 'react-hot-toast';

interface Booking {
  id: number;
  customerName: string;
  customerEmail: string;
  pickupLocation: string;
  destinationLocation: string;
  status: string;
  pickupMapUrl: string;
  destinationMapUrl: string;
  routeMapUrl: string;
}

export default function PendingRequestsPage() {
  const router = useRouter();
  const [bookings, setBookings] = useState<Booking[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [activeMenu, setActiveMenu] = useState('PendingRequests');

  const fetchPendingRequests = async () => {
    const token = sessionStorage.getItem('token');
    if (!token) {
      setError('Unauthorized: Token missing');
      setLoading(false);
      return;
    }

    try {
      const res = await axios.get('http://localhost:3001/booking/requests', {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });

      const pendingBookings = res.data.filter(
        (booking: Booking) => booking.status === 'Pending'
      );
      setBookings(pendingBookings);
    } catch (err: any) {
      console.error('Error fetching pending bookings:', err);
      setError('Could not load booking data');
      toast.error('Could not load booking data', {
        position: 'top-center',
      });
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchPendingRequests();
  }, []);

  const handleAccept = (id: number) => {
    router.push(`/PendingRequests/SetPrice/${id}`);
  };

  const handleReject = async (id: number) => {
    const token = sessionStorage.getItem('token');
    if (!token) {
      setError('Unauthorized: Token missing');
      return;
    }

    try {
      await axios.patch(`http://localhost:3001/booking/reject/${id}`, null, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      toast.success('Booking rejected successfully', {
        position: 'top-center',
      });
      fetchPendingRequests();
    } catch (err) {
      console.error('Error rejecting booking:', err);
      setError('Could not reject booking');
      toast.error('Could not reject booking', {
        position: 'top-center',
      });
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
          
       

        {/* Main Content */}
        <main className="flex-1 overflow-auto p-8">
          <div className="max-w-6xl mx-auto">
            <div className="text-center mb-12">
              <h1 className="text-4xl font-bold mb-4 text-transparent bg-clip-text bg-gradient-to-r from-cyan-400 to-blue-500">
                Pending Booking Requests
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
              <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                {bookings.map((booking) => (
                  <div key={booking.id} className="bg-gray-800/50 backdrop-blur-sm rounded-xl p-6 border border-gray-700 shadow-xl hover:shadow-2xl transition-all">
                    <div className="space-y-4">
                      <div className="flex items-center gap-3">
                        <div className="bg-cyan-500/10 p-3 rounded-full">
                          <FaUser className="text-cyan-400 text-xl" />
                        </div>
                        <div>
                          <h3 className="text-xl font-semibold">{booking.customerName}</h3>
                          <p className="text-gray-400">{booking.customerEmail}</p>
                        </div>
                      </div>

                      <div className="space-y-2">
                        <div className="flex items-center gap-2 text-gray-300">
                          <FaMapMarkerAlt className="text-green-400" />
                          <span>From: {booking.pickupLocation}</span>
                        </div>
                        <div className="flex items-center gap-2 text-gray-300">
                          <FaMapMarkerAlt className="text-red-400" />
                          <span>To: {booking.destinationLocation}</span>
                        </div>
                      </div>

                      <div className="flex gap-3 pt-2">
                        <a
                          href={booking.pickupMapUrl}
                          target="_blank"
                          className="flex items-center gap-1 text-sm text-blue-400 hover:text-blue-300 transition-colors"
                        >
                          <FaMapMarkerAlt size={12} /> Pickup Map
                        </a>
                        <a
                          href={booking.destinationMapUrl}
                          target="_blank"
                          className="flex items-center gap-1 text-sm text-blue-400 hover:text-blue-300 transition-colors"
                        >
                          <FaMapMarkerAlt size={12} /> Destination Map
                        </a>
                        <a
                          href={booking.routeMapUrl}
                          target="_blank"
                          className="flex items-center gap-1 text-sm text-purple-400 hover:text-purple-300 transition-colors"
                        >
                          <FaRoute size={12} /> View Route
                        </a>
                      </div>

                      <div className="flex gap-3 pt-4">
                        <button
                          onClick={() => handleAccept(booking.id)}
                          className="flex-1 flex items-center justify-center gap-2 px-4 py-2 bg-gradient-to-r from-green-600 to-cyan-600 hover:from-green-500 hover:to-cyan-500 rounded-lg transition-all"
                        >
                          <FaCheck /> Accept
                        </button>
                        <button
                          onClick={() => handleReject(booking.id)}
                          className="flex-1 flex items-center justify-center gap-2 px-4 py-2 bg-gradient-to-r from-red-600 to-pink-600 hover:from-red-500 hover:to-pink-500 rounded-lg transition-all"
                        >
                          <FaTimes /> Reject
                        </button>
                      </div>
                    </div>
                  </div>
                ))}
              </div>
            )}

            {!loading && !error && bookings.length === 0 && (
              <div className="text-center py-12">
                <p className="text-xl text-gray-400">No pending booking requests found</p>
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