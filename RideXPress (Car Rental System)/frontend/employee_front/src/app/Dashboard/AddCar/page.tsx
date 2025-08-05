'use client';
import { useState } from 'react';
import axios from 'axios';
import { useRouter } from 'next/navigation';
import { FaCar, FaPlus, FaTrash, FaArrowLeft, FaUpload } from 'react-icons/fa';
import { toast, Toaster } from 'react-hot-toast';

export default function AddCarPage() {
  const router = useRouter();

  const [formData, setFormData] = useState({
    name: '',
    model: '',
    mileage: '',
    fuel_type: '',
    license_number: '',
    damageReport: '',
    carPicture: null as File | null,
  });

  const [error, setError] = useState('');
  const [previewImage, setPreviewImage] = useState<string | null>(null);
  const [isLoading, setIsLoading] = useState(false);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files ? e.target.files[0] : null;
    setFormData(prev => ({ ...prev, carPicture: file }));

    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => setPreviewImage(reader.result as string);
      reader.readAsDataURL(file);
    } else {
      setPreviewImage(null);
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsLoading(true);
    setError('');

    const formDataToSend = new FormData();
    Object.entries(formData).forEach(([key, value]) => {
      if (value !== null) {
        formDataToSend.append(key, value instanceof File ? value : String(value));
      }
    });

    try {
      const token = sessionStorage.getItem('token');
      if (!token) {
        throw new Error('Authentication required');
      }

      await axios.post('http://localhost:3001/car/add', formDataToSend, {
        headers: {
          Authorization: `Bearer ${token}`,
          'Content-Type': 'multipart/form-data',
        },
      });

      toast.success('Car added successfully!', {
        position: 'top-center',
        duration: 3000,
      });
      
      setTimeout(() => router.push('/Dashboard'), 1000);
    } catch (err: any) {
      const errorMsg = err.response?.data?.message || 'Failed to add car';
      setError(errorMsg);
      toast.error(errorMsg, {
        position: 'top-center',
        duration: 3000,
      });
    } finally {
      setIsLoading(false);
    }
  };

  const handleClear = () => {
    setFormData({
      name: '',
      model: '',
      mileage: '',
      fuel_type: '',
      license_number: '',
      damageReport: '',
      carPicture: null,
    });
    setError('');
    setPreviewImage(null);
  };

  return (
    <div className="min-h-screen bg-gradient-to-br from-gray-900 to-gray-800 text-white">
      <Toaster />
      
      <div className="container mx-auto px-4 py-12">
        <button 
          onClick={() => router.push('/Dashboard')}
          className="flex items-center gap-2 mb-6 text-cyan-400 hover:text-cyan-300 transition-colors"
        >
          <FaArrowLeft /> Back to Dashboard
        </button>

        <div className="max-w-2xl mx-auto bg-gray-800/50 backdrop-blur-sm rounded-2xl border border-gray-700 shadow-2xl overflow-hidden">
          {/* Form Header */}
          <div className="bg-gradient-to-r from-cyan-600 to-blue-600 p-6">
            <div className="flex items-center gap-4">
              <div className="p-3 bg-white/20 rounded-full">
                <FaCar className="text-2xl" />
              </div>
              <h1 className="text-2xl font-bold">Add New Vehicle</h1>
            </div>
            <p className="mt-2 text-cyan-100">Fill in the details to add a new car to your fleet</p>
          </div>

          {/* Form Body */}
          <form onSubmit={handleSubmit} className="p-6 space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
              {[
                { id: 'name', label: 'Car Name' },
                { id: 'model', label: 'Model' },
                { id: 'mileage', label: 'Mileage' },
                { id: 'fuel_type', label: 'Fuel Type' },
                { id: 'license_number', label: 'License Number' },
                { id: 'damageReport', label: 'Damage Report' },
              ].map((field) => (
                <div key={field.id} className="space-y-2">
                  <label htmlFor={field.id} className="block text-sm font-medium text-gray-300">
                    {field.label}
                  </label>
                  <input
                    type="text"
                    id={field.id}
                    name={field.id}
                    value={formData[field.id as keyof typeof formData] as string}
                    onChange={handleChange}
                    className="w-full px-4 py-3 bg-gray-700/50 border border-gray-600 rounded-lg focus:outline-none focus:ring-2 focus:ring-cyan-500 focus:border-transparent transition"
                    placeholder={`Enter ${field.label.toLowerCase()}`}
                    required
                  />
                </div>
              ))}
            </div>

            {/* Image Upload */}
            <div className="space-y-4">
              <label className="block text-sm font-medium text-gray-300">
                Car Image
              </label>
              <label className="flex flex-col items-center justify-center w-full h-32 border-2 border-dashed border-gray-600 rounded-lg cursor-pointer bg-gray-700/50 hover:bg-gray-700/70 transition">
                {previewImage ? (
                  <img src={previewImage} alt="Preview" className="h-full w-full object-cover rounded-lg" />
                ) : (
                  <div className="flex flex-col items-center justify-center p-4 text-center">
                    <FaUpload className="text-2xl text-gray-400 mb-2" />
                    <p className="text-sm text-gray-400">
                      <span className="font-semibold">Click to upload</span> or drag and drop
                    </p>
                    <p className="text-xs text-gray-500">PNG, JPG, JPEG (MAX. 5MB)</p>
                  </div>
                )}
                <input 
                  type="file" 
                  name="carPicture" 
                  accept="image/*" 
                  onChange={handleFileChange} 
                  className="hidden" 
                  required
                />
              </label>
            </div>

            {error && (
              <div className="p-4 bg-red-900/50 border border-red-500 rounded-lg">
                {error}
              </div>
            )}

            {/* Form Actions */}
            <div className="flex flex-col sm:flex-row gap-4 pt-4">
              <button
                type="submit"
                disabled={isLoading}
                className={`flex-1 py-3 px-6 rounded-lg font-medium flex items-center justify-center gap-2 transition-all ${
                  isLoading 
                    ? 'bg-gray-600 cursor-not-allowed' 
                    : 'bg-gradient-to-r from-cyan-600 to-blue-600 hover:from-cyan-500 hover:to-blue-500 shadow-lg'
                }`}
              >
                {isLoading ? (
                  <>
                    <svg className="animate-spin h-5 w-5 text-white" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                      <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                      <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                    </svg>
                    Processing...
                  </>
                ) : (
                  <>
                    <FaPlus /> Add Vehicle
                  </>
                )}
              </button>

              <button
                type="button"
                onClick={handleClear}
                className="flex-1 py-3 px-6 bg-gray-700 hover:bg-gray-600 rounded-lg font-medium flex items-center justify-center gap-2 transition-all"
              >
                <FaTrash /> Clear Form
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}