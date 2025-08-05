'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import axios from 'axios';
import { FaUser, FaEnvelope, FaPhone, FaMapMarkerAlt, FaSave, FaTimes, FaCamera, FaLock } from 'react-icons/fa';
import toast, { Toaster } from 'react-hot-toast';

interface Profile {
  name: string;
  email: string;
  phone: string;
  address: string;
  password: string;
  profilePicture?: string;
}

export default function UpdateProfilePage() {
  const router = useRouter();
  const [profile, setProfile] = useState<Profile>({
    name: '',
    email: '',
    phone: '',
    address: '',
    password: '********', 
    profilePicture: ''
  });
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [isUpdating, setIsUpdating] = useState(false);
  const [selectedFile, setSelectedFile] = useState<File | null>(null);
  const [previewImage, setPreviewImage] = useState<string | null>(null);
  const [showPassword, setShowPassword] = useState(false);

  useEffect(() => {
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
        setProfile({
          ...response.data,
          password: '' // Set initial password value
        });
        if (response.data.profilePicture) {
          setPreviewImage(response.data.profilePicture);
        }
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

    fetchProfile();
  }, [router]);

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setProfile(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files && e.target.files[0]) {
      const file = e.target.files[0];
      setSelectedFile(file);
      
      const reader = new FileReader();
      reader.onloadend = () => {
        setPreviewImage(reader.result as string);
      };
      reader.readAsDataURL(file);
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsUpdating(true);
    const token = sessionStorage.getItem('token');
    
    if (!token) {
      toast.error('You need to be logged in to update your profile', {
        position: 'top-center',
      });
      setIsUpdating(false);
      return;
    }

    try {
      const passwordToSend = profile.password === '********' ? '' : profile.password;
      
      const updatePayload = {
        name: profile.name,
        email: profile.email,
        phone: profile.phone,
        address: profile.address,
        password: passwordToSend || 'dummyPassword123' // Send minimum required if not changing
      };

      if (selectedFile) {
        const formData = new FormData();
        formData.append('profilePicture', selectedFile);
        
        const pictureResponse = await axios.post(
          'http://localhost:3001/profile/update-picture',
          formData,
          {
            headers: {
              Authorization: `Bearer ${token}`,
              'Content-Type': 'multipart/form-data',
            },
          }
        );

        
       const updatedPictureUrl = pictureResponse.data.profilePicture.startsWith('http') 
       ? pictureResponse.data.profilePicture
      : `http://localhost:3001${pictureResponse.data.profilePicture}`;
        
        setPreviewImage(pictureResponse.data.profilePicture);
      }

      await axios.patch(
        'http://localhost:3001/profile/update',
        updatePayload,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      toast.success('Profile updated successfully', {
        position: 'top-center',
      });
      router.push('/profile');
    } catch (err: any) {
      console.error('Error updating profile:', err);
      const errorMsg = err.response?.data?.message || 'Failed to update profile';
      toast.error(errorMsg, {
        position: 'top-center',
      });
    } finally {
      setIsUpdating(false);
    }
  };

  const handleCancel = () => {
    router.push('/profile');
  };

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
    if (!showPassword && profile.password === '********') {
      setProfile(prev => ({ ...prev, password: '' }));
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
                  className={`w-full text-left px-4 py-3 rounded-lg transition-all ${item === 'profile' ? 
                    'bg-gradient-to-r from-blue-600 to-cyan-500 text-white shadow-lg' : 
                    'text-gray-300 hover:bg-gray-700/50 hover:text-white'}`}
                  onClick={() => router.push(`/${item}`)}
                >
                  {item.replace(/([A-Z])/g, ' $1').trim()}
                </button>
              </li>
            ))}
          </ul>
        </aside>

        <main className="flex-1 overflow-auto p-8">
          <div className="max-w-3xl mx-auto">
            <div className="text-center mb-12">
              <h1 className="text-4xl font-bold mb-4 text-transparent bg-clip-text bg-gradient-to-r from-cyan-400 to-blue-500">
                Update Profile
              </h1>
              <p className="text-gray-400 max-w-lg mx-auto">
                Edit your personal information
              </p>
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
              <form onSubmit={handleSubmit}>
                <div className="bg-gray-800/50 backdrop-blur-sm p-8 rounded-2xl border border-gray-700 shadow-2xl">
                  <div className="flex flex-col items-center mb-8">
                    <div className="relative">
                      <img
                        src={previewImage || profile.profilePicture || '/default-profile.png'}
                        alt="Profile"
                        className="w-32 h-32 rounded-full border-4 border-cyan-500/80 object-cover shadow-xl"
                        onError={(e) => {
                          (e.target as HTMLImageElement).src = '/default-profile.png';
                        }}
                      />
                      <label className="absolute bottom-0 right-0 bg-cyan-600 hover:bg-cyan-500 text-white p-2 rounded-full shadow-lg transition-all cursor-pointer">
                        <FaCamera />
                        <input
                          type="file"
                          className="hidden"
                          accept="image/*"
                          onChange={handleFileChange}
                        />
                      </label>
                    </div>
                  </div>

                  <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                    <div className="space-y-2">
                      <label className="flex items-center gap-2 text-gray-300">
                        <FaUser className="text-cyan-400" /> Full Name
                      </label>
                      <input
                        type="text"
                        name="name"
                        value={profile.name}
                        onChange={handleInputChange}
                        className="w-full p-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500"
                        required
                      />
                    </div>

                    <div className="space-y-2">
                      <label className="flex items-center gap-2 text-gray-300">
                        <FaEnvelope className="text-cyan-400" /> Email
                      </label>
                      <input
                        type="email"
                        name="email"
                        value={profile.email}
                        onChange={handleInputChange}
                        className="w-full p-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500"
                        required
                      />
                    </div>

                    <div className="space-y-2">
                      <label className="flex items-center gap-2 text-gray-300">
                        <FaPhone className="text-cyan-400" /> Phone Number
                      </label>
                      <input
                        type="tel"
                        name="phone"
                        value={profile.phone}
                        onChange={handleInputChange}
                        className="w-full p-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500"
                        required
                      />
                    </div>

                    <div className="space-y-2">
                      <label className="flex items-center gap-2 text-gray-300">
                        <FaMapMarkerAlt className="text-cyan-400" /> Address
                      </label>
                      <input
                        type="text"
                        name="address"
                        value={profile.address}
                        onChange={handleInputChange}
                        className="w-full p-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500"
                        required
                      />
                    </div>

                    <div className="space-y-2">
                      <label className="flex items-center gap-2 text-gray-300">
                        <FaLock className="text-cyan-400" /> Password
                      </label>
                      <div className="relative">
                        <input
                          type={showPassword ? "text" : "password"}
                          name="password"
                          value={profile.password}
                          onChange={handleInputChange}
                          className="w-full p-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500 pr-10"
                          minLength={6}
                          required
                        />
                        <button
                          type="button"
                          onClick={togglePasswordVisibility}
                          className="absolute right-3 top-3 text-gray-400 hover:text-cyan-400"
                        >
                          {showPassword ? 'Hide' : 'Show'}
                        </button>
                      </div>
                      <p className="text-xs text-gray-500 mt-1">
                        {profile.password === '********' 
                          ? "Enter new password to change it" 
                          : "Minimum 6 characters required"}
                      </p>
                    </div>
                  </div>

                  <div className="mt-10 flex flex-col sm:flex-row gap-4 justify-center">
                    <button
                      type="submit"
                      disabled={isUpdating}
                      className="flex items-center justify-center gap-2 px-6 py-3 bg-gradient-to-r from-cyan-600 to-blue-600 hover:from-cyan-500 hover:to-blue-500 rounded-lg transition-all shadow-lg hover:shadow-cyan-500/20 disabled:opacity-70"
                    >
                      <FaSave /> {isUpdating ? 'Updating...' : 'Save Changes'}
                    </button>

                    <button
                      type="button"
                      onClick={handleCancel}
                      className="flex items-center justify-center gap-2 px-6 py-3 bg-gradient-to-r from-gray-600 to-gray-700 hover:from-gray-500 hover:to-gray-600 rounded-lg transition-all shadow-lg hover:shadow-gray-500/20"
                    >
                      <FaTimes /> Cancel
                    </button>
                  </div>
                </div>
              </form>
            )}
          </div>
        </main>
      </div>
    </div>
  );
}