'use client';
import { useState } from 'react';
import toast, { Toaster } from 'react-hot-toast';

export default function RegisterPage() {
  const [name, setName] = useState('');
  const [phone, setPhone] = useState('');
  const [address, setAddress] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [profilePicture, setProfilePicture] = useState<File | null>(null);
  const [errors, setErrors] = useState<Record<string, string>>({});

  const validateForm = () => {
    const newErrors: Record<string, string> = {};

    if (!name.trim()) newErrors.name = 'Name is required';
    
    if (!email.trim()) {
      newErrors.email = 'Email is required';
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
      newErrors.email = 'Please enter a valid email';
    }

    if (!phone.trim()) {
      newErrors.phone = 'Phone is required';
    } else if (!/^\+8801[3-9]\d{8}$/.test(phone)) {
      newErrors.phone = 'Phone must be a valid Bangladeshi number (e.g., +8801712345678)';
    }

    if (!address.trim()) newErrors.address = 'Address is required';
    
    if (!password) {
      newErrors.password = 'Password is required';
    } else if (password.length < 6) {
      newErrors.password = 'Password must be at least 6 characters';
    }

    if (!profilePicture) newErrors.profilePicture = 'Profile picture is required';

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleRegister = async (e: React.FormEvent) => {
    e.preventDefault();

    if (!validateForm()) return;

    const formData = new FormData();
    formData.append('name', name);
    formData.append('phone', phone);
    formData.append('address', address);
    formData.append('email', email);
    formData.append('password', password);
    if (profilePicture) formData.append('profilePicture', profilePicture);

    try {
      const response = await fetch('http://localhost:3001/authentication/signup', {
        method: 'POST',
        body: formData,
      });

      const data = await response.json();

      if (!response.ok) {
        toast.error(data.message || 'Registration failed');
        return;
      }

      toast.success('Registration successful! Redirecting to login...');
      setTimeout(() => {
        window.location.href = '/login';
      }, 2000);
    } catch (error) {
      console.error("Registration error:", error);
      toast.error('Something went wrong. Please try again.');
    }
  };

  return (
    <div className="relative min-h-screen flex items-center justify-center px-4">
      {/* Add Toaster component at the top level */}
      <Toaster 
        position="top-center"
        toastOptions={{
          duration: 3000,
          style: {
            background: '#363636',
            color: '#fff',
          },
        }}
      />
      
      <img src="/images/register-bg.jpg" className="absolute inset-0 w-full h-full object-cover z-0" />
      <div className="absolute inset-0 bg-gradient-to-r from-blue-900 to-indigo-900 opacity-80 z-0" />
      <div className="relative z-10 bg-white p-10 rounded-2xl shadow-2xl w-full max-w-md">
        <div className="text-center mb-6">
          <h1 className="text-4xl font-bold text-blue-700">RideXPress</h1>
          <p className="text-gray-600 mt-2">Create your account to start booking rides</p>
        </div>

        <form onSubmit={handleRegister} className="space-y-4" encType="multipart/form-data">
          {/* ... rest of your form fields remain the same ... */}
          <div>
            <input 
              type="text" 
              placeholder="Name" 
              value={name} 
              onChange={(e) => setName(e.target.value)} 
              className={`input input-bordered w-full ${errors.name ? 'input-error' : ''}`} 
            />
            {errors.name && <p className="text-red-500 text-xs mt-1">{errors.name}</p>}
          </div>
          
          <div>
            <input 
              type="tel" 
              placeholder="Phone (e.g., +8801712345678)" 
              value={phone} 
              onChange={(e) => setPhone(e.target.value)} 
              className={`input input-bordered w-full ${errors.phone ? 'input-error' : ''}`} 
            />
            {errors.phone && <p className="text-red-500 text-xs mt-1">{errors.phone}</p>}
          </div>
          
          <div>
            <input 
              type="text" 
              placeholder="Address" 
              value={address} 
              onChange={(e) => setAddress(e.target.value)} 
              className={`input input-bordered w-full ${errors.address ? 'input-error' : ''}`} 
            />
            {errors.address && <p className="text-red-500 text-xs mt-1">{errors.address}</p>}
          </div>
          
          <div>
            <input 
              type="email" 
              placeholder="Email" 
              value={email} 
              onChange={(e) => setEmail(e.target.value)} 
              className={`input input-bordered w-full ${errors.email ? 'input-error' : ''}`} 
            />
            {errors.email && <p className="text-red-500 text-xs mt-1">{errors.email}</p>}
          </div>
          
          <div>
            <input 
              type="password" 
              placeholder="Password (min 6 characters)" 
              value={password} 
              onChange={(e) => setPassword(e.target.value)} 
              className={`input input-bordered w-full ${errors.password ? 'input-error' : ''}`} 
            />
            {errors.password && <p className="text-red-500 text-xs mt-1">{errors.password}</p>}
          </div>
          
          <div className="w-full">
            <label className="block text-sm font-medium text-gray-700 mb-1">Profile Picture</label>
            <div className="flex items-center gap-4">
              <label className="cursor-pointer bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 transition">
                Choose File
                <input
                  type="file"
                  accept="image/*"
                  onChange={(e) => setProfilePicture(e.target.files?.[0] || null)}
                  className="hidden"
                />
              </label>
              {profilePicture && (
                <span className="text-sm text-gray-600 truncate max-w-[200px]">{profilePicture.name}</span>
              )}
            </div>
            {errors.profilePicture && <p className="text-red-500 text-xs mt-1">{errors.profilePicture}</p>}
          </div>

          <button type="submit" className="btn btn-primary w-full">Register</button>
        </form>

        <div className="text-center mt-4 text-sm text-black">
          Already have an account? <a href="/login" className="text-blue-500 hover:underline">Login</a>
        </div>
      </div>
    </div>
  );
}