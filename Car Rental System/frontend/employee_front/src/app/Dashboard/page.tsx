'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import axios from 'axios';
import { FaCar, FaUser, FaEdit, FaTrash, FaPlus, FaChartBar, FaSignOutAlt } from 'react-icons/fa';
import toast, { Toaster } from 'react-hot-toast';

export default function DashboardPage() {
  const router = useRouter();
  const images = [
    '/images/car1.jpg',
    '/images/car2.jpg',
    '/images/car3.jpeg',
    '/images/car4.jpeg',
    '/images/car5.jpg',
    '/images/car6.png',
    '/images/car7.jpeg',
    '/images/car8.jpg',
    '/images/car9.jpg',
    '/images/car10.jpg',
  ];

  const [cars, setCars] = useState<any[]>([]);
  const [profile, setProfile] = useState<any | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [activeMenu, setActiveMenu] = useState('Dashboard');
  const [searchQuery, setSearchQuery] = useState('');

  const fetchCars = async () => {
    const token = sessionStorage.getItem('token');
    if (!token) {
      setError('Unauthorized: Token missing');
      setLoading(false);
      return;
    }

    try {
      const res = await axios.get('http://localhost:3001/car/list', {
        headers: { Authorization: `Bearer ${token}` },
      });
      setCars(res.data);
    } catch (err: any) {
      setError('Could not load car data');
    } finally {
      setLoading(false);
    }
  };

    










  const fetchProfile = async () => {
    const token = sessionStorage.getItem('token');
    if (!token) return;
    try {
      const res = await axios.get('http://localhost:3001/profile/view', {
        headers: { Authorization: `Bearer ${token}` },
      });
      setProfile(res.data);
    } catch {
      console.error('Error fetching profile');
    }
  };

  useEffect(() => {
    fetchCars();
    fetchProfile();
  }, []);

  const handleDelete = async (id: number) => {
    const token = sessionStorage.getItem('token');
    if (!token) return;
    try {
      await axios.delete(`http://localhost:3001/car/${id}/delete`, {
        headers: { Authorization: `Bearer ${token}` },
      });
      toast.success('Car deleted successfully!', {
        duration: 3000,
        position: 'top-center',
      });
      fetchCars();
    } catch {
      toast.error('Delete failed', {
        duration: 3000,
        position: 'top-center',
      });
    }
  };

  const handleStatistics = () => {
    router.push('/Dashboard/Statistics');
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

  const handleUpdateProfile = () => {
    router.push('http://localhost:3000/profile');
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
            className="w-full mt-12 px-4 py-3 bg-red-600/90 hover:bg-red-500 text-white rounded-lg transition-all flex items-center justify-center gap-2"
            onClick={handleLogout}
          >
            <FaSignOutAlt /> Logout
          </button>
        </aside>

        {/* Main Content */}
        <main className="flex-1 overflow-auto p-8">
          <div className="max-w-7xl mx-auto">
            <h1 className="text-4xl font-bold mb-8 text-transparent bg-clip-text bg-gradient-to-r from-cyan-400 to-blue-500">
              Dashboard Overview
            </h1>

            {/* Carousel */}
            <div className="relative w-full mb-12 overflow-hidden">
              <div className="animate-marquee whitespace-nowrap">
                {[...images, ...images].map((src, index) => (
                  <img 
                    key={index} 
                    src={src} 
                    alt={`car-${index}`} 
                    className="inline-block h-64 w-auto rounded-xl mx-2 object-cover shadow-lg" 
                  />
                ))}
              </div>
            </div>

            {/* Dashboard Content */}
            <div className="grid grid-cols-1 lg:grid-cols-3 gap-8 mb-8">
              {/* Profile Card */}
              <div className="bg-gray-800/50 backdrop-blur-sm p-6 rounded-2xl border border-gray-700 shadow-xl">
                <div className="flex flex-col items-center">
                  <div className="relative mb-4">
                    <img
                      src={profile?.profilePicture ? profile.profilePicture : '/uploads/profile/default-profile.jpg'}
                      alt="Profile"
                      className="w-32 h-32 rounded-full object-cover border-4 border-cyan-500/50"
                    />
                  </div>
                  <h2 className="text-xl font-semibold text-center mb-1">{profile?.name || 'Name unavailable'}</h2>
                  <p className="text-gray-400 text-sm mb-4">{profile?.email || 'Email unavailable'}</p>
                  <button 
                    onClick={handleUpdateProfile}
                    className="bg-gradient-to-r from-cyan-600 to-blue-600 hover:from-cyan-500 hover:to-blue-500 text-white px-6 py-2 rounded-lg flex items-center gap-2 transition-all"
                  >
                    <FaEdit /> Update Profile
                  </button>
                </div>
              </div>

              {/* Statistics Card */}
              <div className="bg-gray-800/50 backdrop-blur-sm p-6 rounded-2xl border border-gray-700 shadow-xl flex flex-col justify-between">
                <div>
                  <h3 className="text-xl font-semibold mb-4">Quick Stats</h3>
                  <div className="grid grid-cols-2 gap-4">
                    <div className="bg-gray-700/50 p-4 rounded-lg">
                      <p className="text-gray-400 text-sm">Total Cars</p>
                      <p className="text-2xl font-bold">{cars.length}</p>
                    </div>
                    <div className="bg-gray-700/50 p-4 rounded-lg">
                      <p className="text-gray-400 text-sm">Booked Cars</p>
                      <p className="text-2xl font-bold">{cars.filter(car => car.isBooked).length}</p>
                    </div>
                  </div>
                </div>
                <button
                  onClick={handleStatistics}
                  className="bg-gradient-to-r from-purple-600 to-indigo-600 hover:from-purple-500 hover:to-indigo-500 text-white px-6 py-2 rounded-lg flex items-center justify-center gap-2 mt-6 transition-all"
                >
                  <FaChartBar /> View Statistics
                </button>
              </div>

              {/* Add Car Card */}
              <div className="bg-gray-800/50 backdrop-blur-sm p-6 rounded-2xl border border-gray-700 shadow-xl flex flex-col justify-center items-center">
                <div className="text-center mb-6">
                  <h3 className="text-xl font-semibold mb-2">Add New Vehicle</h3>
                  <p className="text-gray-400 text-sm">Expand your fleet with a new addition</p>
                </div>
                <button
                  onClick={() => router.push('/Dashboard/AddCar')}
                  className="bg-gradient-to-r from-green-600 to-teal-600 hover:from-green-500 hover:to-teal-500 text-white px-6 py-3 rounded-lg flex items-center gap-2 transition-all"
                >
                  <FaPlus /> Add New Car
                </button>
              </div>
            </div>

           {/* Cars Table */}
<div className="bg-gray-800/50 backdrop-blur-sm p-6 rounded-2xl border border-gray-700 shadow-xl">
  <div className="flex justify-between items-center mb-6">
    <h2 className="text-2xl font-semibold">Vehicle Inventory</h2>
    <div className="relative">
      <input
        type="text"
        placeholder="Search vehicles..."
        className="bg-gray-700/50 border border-gray-600 rounded-lg px-4 py-2 pl-10 focus:outline-none focus:ring-2 focus:ring-cyan-500 w-64"
        value={searchQuery}
        onChange={(e) => setSearchQuery(e.target.value)}
      />
      <svg
        className="absolute left-3 top-3 h-4 w-4 text-gray-400"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor"
      >
        <path
          strokeLinecap="round"
          strokeLinejoin="round"
          strokeWidth={2}
          d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
        />
      </svg>
    </div>
  </div>

  {loading && (
    <div className="flex justify-center py-12">
      <div className="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-cyan-500"></div>
    </div>
  )}

  {error && (
    <div className="p-4 bg-red-900/50 border border-red-500 rounded-lg mb-6">
      {error}
    </div>
  )}

  {!loading && !error && (
    <div className="overflow-x-auto">
      <table className="w-full border-collapse">
        <thead>
          <tr className="bg-gray-700 text-left">
            <th className="p-4 font-medium">ID</th>
            <th className="p-4 font-medium">Name</th>
            <th className="p-4 font-medium">Model</th>
            <th className="p-4 font-medium">Mileage</th>
            <th className="p-4 font-medium">Fuel</th>
            <th className="p-4 font-medium">License</th>
            <th className="p-4 font-medium">Image</th>
            <th className="p-4 font-medium">Availability</th>
            <th className="p-4 font-medium text-right">Actions</th>
          </tr>
        </thead>
        <tbody>
          {cars
            .filter((car) => {
              if (!searchQuery) return true;
              return (
                car.name.toLowerCase().includes(searchQuery.toLowerCase()) ||
                car.model.toLowerCase().includes(searchQuery.toLowerCase()) ||
                car.license_number.toLowerCase().includes(searchQuery.toLowerCase()) ||
                car.fuel_type.toLowerCase().includes(searchQuery.toLowerCase())
              );
            })
            .map((car: any) => (
              <tr key={car.id} className="border-b border-gray-700 hover:bg-gray-700/30 transition-colors">
                <td className="p-4">{car.id}</td>
                <td className="p-4 font-medium">{car.name}</td>
                <td className="p-4">{car.model}</td>
                <td className="p-4">{car.mileage}</td>
                <td className="p-4">{car.fuel_type}</td>
                <td className="p-4">{car.license_number}</td>
                <td className="p-4">
                  {car.carPicture ? (
                    <img
                      src={`http://localhost:3001${car.carPicture}`}
                      alt="Car"
                      className="w-16 h-16 object-cover rounded"
                    />
                  ) : (
                    <div className="w-16 h-16 bg-gray-700/50 rounded flex items-center justify-center">
                      <FaCar className="text-gray-500" />
                    </div>
                  )}
                </td>
                <td className="p-4">
                  <span className={`inline-flex items-center px-3 py-1 rounded-full text-sm font-medium ${
                    car.isBooked 
                      ? 'bg-red-100 text-red-800' 
                      : 'bg-green-100 text-green-800'
                  }`}>
                    {car.isBooked ? 'Booked' : 'Available'}
                  </span>
                </td>
                <td className="p-4 flex justify-end gap-2">
                  <button
                    onClick={() => router.push(`/Dashboard/UpdateCar?id=${car.id}`)}
                    className="bg-amber-600 hover:bg-amber-500 text-white p-2 rounded-lg transition-all"
                    title="Edit"
                  >
                    <FaEdit />
                  </button>
                  <button
                    onClick={() => handleDelete(car.id)}
                    className="bg-red-600 hover:bg-red-500 text-white p-2 rounded-lg transition-all"
                    title="Delete"
                  >
                    <FaTrash />
                  </button>
                </td>
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  )}
</div>
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

      <style jsx>{`
        @keyframes marquee {
          0% { transform: translateX(0); }
          100% { transform: translateX(-50%); }
        }
        .animate-marquee {
          display: inline-block;
          animation: marquee 20s linear infinite;
        }
      `}</style>
    </div>
  );
}