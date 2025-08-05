'use client';
import { useEffect, useState } from 'react';
import { useSearchParams, useRouter } from 'next/navigation';
import axios from 'axios';
import { FaTrash, FaUpload } from 'react-icons/fa';
import toast, { Toaster } from 'react-hot-toast';

export default function UpdateCarPage() {
  const searchParams = useSearchParams();
  const router = useRouter();
  const id = searchParams.get('id');

  const [formData, setFormData] = useState({
    name: '',
    model: '',
    mileage: '',
    fuel_type: '',
    license_number: '',
    damageReport: '',
  });

  const [carPicture, setCarPicture] = useState<File | null>(null);
  const [previewImage, setPreviewImage] = useState<string | null>(null);
  const [error, setError] = useState('');
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const fetchCar = async () => {
      const token = sessionStorage.getItem('token');
      if (!token || !id) return;

      try {
        setIsLoading(true);
        const res = await axios.get(`http://localhost:3001/car/${id}`, {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });
        
        // Set form data from API response
        setFormData({
          name: res.data.name || '',
          model: res.data.model || '',
          mileage: res.data.mileage || '',
          fuel_type: res.data.fuel_type || '',
          license_number: res.data.license_number || '',
          damageReport: res.data.damageReport || '',
        });
        
        // Set preview image if exists
        if (res.data.carPicture) {
          setPreviewImage(`http://localhost:3001${res.data.carPicture}`);
        }
      } catch (err) {
        console.error('Error fetching car data:', err);
        setError('Failed to load car data');
      } finally {
        setIsLoading(false);
      }
    };
    fetchCar();
  }, [id]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files && e.target.files[0]) {
      const file = e.target.files[0];
      setCarPicture(file);
      
      // Create preview URL
      const reader = new FileReader();
      reader.onloadend = () => {
        setPreviewImage(reader.result as string);
      };
      reader.readAsDataURL(file);
    }
  };

  const handleRemoveImage = () => {
    setCarPicture(null);
    setPreviewImage(null);
  };

  const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  const token = sessionStorage.getItem('token');
  if (!token || !id) return;

  setIsLoading(true);
  setError('');

  try {
    const carDto = {
      name: formData.name,
      model: formData.model,
      mileage: formData.mileage,
      fuel_type: formData.fuel_type,
      license_number: formData.license_number,
      damageReport: formData.damageReport,
    };

    const response = await axios.patch(`http://localhost:3001/car/${id}/update`, carDto, {
      headers: {
        Authorization: `Bearer ${token}`,
        'Content-Type': 'application/json',
      },
      validateStatus: (status) => status < 500 // Don't throw for 400 errors
    });

    if (response.status === 400) {
      setError(response.data.message || 'Validation failed');
      toast.error(response.data.message || 'Validation failed', {
        duration: 3000,
        position: 'top-center',
      });
      return;
    }

    // Handle picture upload if needed
    if (carPicture) {
      const formDataToSend = new FormData();
      formDataToSend.append('carPicture', carPicture);
      
      await axios.patch(`http://localhost:3001/car/${id}/upload-picture`, formDataToSend, {
        headers: {
          Authorization: `Bearer ${token}`,
          'Content-Type': 'multipart/form-data',
        },
      });
    }

    toast.success('Car updated successfully!', {
      duration: 3000,
      position: 'top-center',
    });
    
    setTimeout(() => {
      router.push('/Dashboard');
    }, 1000);
  } catch (err: any) {
    // This will only catch non-400 errors now
    console.error('Update error:', err);
    const errorMessage = err.response?.data?.message || 
                       err.response?.data?.error || 
                       'Failed to update car';
    setError(errorMessage);
    toast.error(errorMessage, {
      duration: 3000,
      position: 'top-center',
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
    });
    setCarPicture(null);
    setPreviewImage(null);
    setError('');
  };

  return (
    <div className="min-h-screen bg-gradient-to-br from-sky-100 to-indigo-100 flex justify-center items-center p-4 font-sans">
      <Toaster />
      <form
        onSubmit={handleSubmit}
        className="bg-white p-8 rounded-2xl shadow-xl w-full max-w-2xl space-y-6 border border-gray-300"
      >
        <h2 className="text-3xl font-bold text-center text-indigo-700">Update Car Details</h2>

        {/* Image Upload Section */}
        <div className="flex flex-col items-center space-y-4">
          <div className="relative w-40 h-40 rounded-lg overflow-hidden border-2 border-dashed border-gray-300 flex items-center justify-center">
            {previewImage ? (
              <>
                <img 
                  src={previewImage} 
                  alt="Car preview" 
                  className="w-full h-full object-cover"
                />
                
              </>
            ) : (
              <div className="text-center p-4">
                <FaUpload className="mx-auto text-gray-400 text-2xl mb-2" />
                <p className="text-sm text-gray-500">No image selected</p>
              </div>
            )}
          </div>

          <label className="cursor-pointer bg-indigo-600 text-white px-4 py-2 rounded-lg hover:bg-indigo-700 transition-colors">
            <span>{carPicture ? 'Change Image' : 'Upload Image'}</span>
            <input
              type="file"
              accept="image/*"
              onChange={handleFileChange}
              className="hidden"
            />
          </label>
        </div>

        {/* Form Fields */}
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4 text-black">
          {['name', 'model', 'mileage', 'fuel_type', 'license_number', 'damageReport'].map((field) => (
            <div key={field} className="space-y-1">
              <label className="block text-sm font-medium text-gray-700">
                {field.replace('_', ' ').charAt(0).toUpperCase() + field.replace('_', ' ').slice(1)}
              </label>
              <input
                type={field === 'mileage' ? 'number' : 'text'}
                name={field}
                placeholder={`Enter ${field.replace('_', ' ')}`}
                className="input input-bordered w-full bg-gray-100 text-black p-2 rounded border border-gray-300 focus:outline-none focus:ring-2 focus:ring-indigo-500"
                value={(formData as any)[field]}
                onChange={handleChange}
                required={field !== 'damageReport'}
              />
            </div>
          ))}
        </div>

        {error && <p className="text-red-600 text-center font-medium">{error}</p>}

        <div className="flex justify-center gap-4 pt-4">
          <button 
            type="submit" 
            className="btn bg-indigo-600 text-white hover:bg-indigo-700 px-6 py-2 rounded-lg disabled:opacity-50"
            disabled={isLoading}
          >
            {isLoading ? 'Updating...' : 'Update Car'}
          </button>
          <button
            type="button"
            onClick={handleClear}
            className="btn bg-yellow-500 text-white hover:bg-yellow-600 px-6 py-2 rounded-lg"
          >
            Clear
          </button>
          <button
            type="button"
            onClick={() => router.push('/Dashboard')}
            className="btn bg-gray-700 text-white hover:bg-gray-800 px-6 py-2 rounded-lg"
          >
            Back to Dashboard
          </button>
        </div>
      </form>
    </div>
  );
}