'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import axios from 'axios';
import { FaUser, FaEnvelope, FaPhone, FaMapMarkerAlt, FaEdit, FaTrash, FaSignOutAlt } from 'react-icons/fa';
import toast, { Toaster } from 'react-hot-toast';

interface Profile {
  name: string;
  email: string;
  phone: string;
  address: string;
  profilePicture?: string;
}

export default function ProfilePage() {
  const router = useRouter();
  const [profile, setProfile] = useState<Profile | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [activeMenu, setActiveMenu] = useState('profile');

  const fetchProfile = async () => {
    const token = sessionStorage.getItem('token');
    if (!token) {
      setError('Unauthorized: Token missing');
      setLoading(false);
      router.push('/login');
      return;
    }

    try {
      const response = await axios.get('http://localhost:3001/profile/view', {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      setProfile(response.data);
    } catch (err: any) {
      console.error('Error fetching profile data:', err);
      setError('Could not load profile data');
      toast.error('Could not load profile data', {
        position: 'top-center',
      });
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchProfile();
  }, []);

  const handleUpdateProfile = () => {
    router.push('/profile/UpdateProfile');
  };

  const handleDeleteProfile = async () => {
  const token = sessionStorage.getItem('token');
  if (!token) {
    toast.error('You need to be logged in to delete your profile', {
      position: 'top-center',
    });
    return;
  }

  try {
    // First request OTP via POST /profile/delete/request
    await axios.post(
      'http://localhost:3001/profile/delete/request',
      {}, // empty body
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    toast.success('OTP sent to your registered phone number', {
      position: 'top-center',
    });

    // Prompt user for OTP
    const otp = prompt('Enter the 6-digit OTP sent to your phone number to confirm deletion:');
    if (!otp) {
      toast.error('Deletion cancelled - no OTP provided', {
        position: 'top-center',
      });
      return;
    }

    // Confirm deletion with OTP via DELETE /profile/delete/confirm?otp=...
    const response = await axios.delete(
      'http://localhost:3001/profile/delete/confirm',
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
        params: { otp }, // sends as query parameter
      }
    );

    if (response.data.message === 'Profile deleted successfully') {
      toast.success('Profile deleted successfully', {
        position: 'top-center',
      });
      sessionStorage.removeItem('token');
      router.push('/login');
    } else {
      throw new Error('Failed to delete profile');
    }
  } catch (err: any) {
    console.error('Error deleting profile:', err);
    const errorMsg = err.response?.data?.message || 'Failed to delete profile';
    toast.error(errorMsg, {
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
    // Call backend logout endpoint
    await axios.post('http://localhost:3001/authentication/logout', {}, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });

    // Clear frontend session
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
          <div className="max-w-3xl mx-auto">
            <div className="text-center mb-12">
              <h1 className="text-4xl font-bold mb-4 text-transparent bg-clip-text bg-gradient-to-r from-cyan-400 to-blue-500">
                Your Profile
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

            {!loading && !error && profile && (
              <div className="bg-gray-800/50 backdrop-blur-sm p-8 rounded-2xl border border-gray-700 shadow-2xl">
                {/* Profile Picture */}
                <div className="flex flex-col items-center mb-8">
                  <div className="relative">
                    <img
                      src={profile.profilePicture || '/default-profile.png'}
                      alt="Profile"
                      className="w-32 h-32 rounded-full border-4 border-cyan-500/80 object-cover shadow-xl"
                    />
                    <button 
                      onClick={handleUpdateProfile}
                      className="absolute bottom-0 right-0 bg-cyan-600 hover:bg-cyan-500 text-white p-2 rounded-full shadow-lg transition-all"
                    >
                      <FaEdit />
                    </button>
                  </div>
                </div>

                {/* Profile Details */}
                <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                  <div className="space-y-2">
                    <label className="flex items-center gap-2 text-gray-300">
                      <FaUser className="text-cyan-400" /> Full Name
                    </label>
                    <div className="p-3 bg-gray-700/50 border border-gray-600 rounded-lg">
                      <p className="text-lg">{profile.name}</p>
                    </div>
                  </div>

                  <div className="space-y-2">
                    <label className="flex items-center gap-2 text-gray-300">
                      <FaEnvelope className="text-cyan-400" /> Email
                    </label>
                    <div className="p-3 bg-gray-700/50 border border-gray-600 rounded-lg">
                      <p className="text-lg">{profile.email}</p>
                    </div>
                  </div>

                  <div className="space-y-2">
                    <label className="flex items-center gap-2 text-gray-300">
                      <FaPhone className="text-cyan-400" /> Phone Number
                    </label>
                    <div className="p-3 bg-gray-700/50 border border-gray-600 rounded-lg">
                      <p className="text-lg">{profile.phone}</p>
                    </div>
                  </div>

                  <div className="space-y-2">
                    <label className="flex items-center gap-2 text-gray-300">
                      <FaMapMarkerAlt className="text-cyan-400" /> Address
                    </label>
                    <div className="p-3 bg-gray-700/50 border border-gray-600 rounded-lg">
                      <p className="text-lg">{profile.address}</p>
                    </div>
                  </div>
                </div>

                {/* Action Buttons */}
                <div className="mt-10 flex flex-col sm:flex-row gap-4 justify-center">
                  <button
                    onClick={handleUpdateProfile}
                    className="flex items-center justify-center gap-2 px-6 py-3 bg-gradient-to-r from-cyan-600 to-blue-600 hover:from-cyan-500 hover:to-blue-500 rounded-lg transition-all shadow-lg hover:shadow-cyan-500/20"
                  >
                    <FaEdit /> Update Profile
                  </button>

                  <button
                    onClick={handleDeleteProfile}
                    className="flex items-center justify-center gap-2 px-6 py-3 bg-gradient-to-r from-red-600 to-pink-600 hover:from-red-500 hover:to-pink-500 rounded-lg transition-all shadow-lg hover:shadow-red-500/20"
                  >
                    <FaTrash /> Delete Account
                  </button>
                </div>
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