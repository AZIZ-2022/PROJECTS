'use client';

import { useState, useEffect } from 'react';
import { useRouter, useParams } from 'next/navigation';
import axios from 'axios';
import { FaMapMarkerAlt, FaRoute, FaCheck, FaTimes, FaArrowLeft } from 'react-icons/fa';

const silentAxios = axios.create();
silentAxios.interceptors.response.use(
  response => response,
  error => {
    if (error.response?.status === 400) {
      return Promise.reject({
        ...error,
        suppressLog: true
      });
    }
    return Promise.reject(error);
  }
);

interface Booking {
  id: number;
  customerName: string;
  customerEmail: string;
  pickupLocation: string;
  destinationLocation: string;
  status: string;
  distance: number | null;
  price: number | null;
  pickupMapUrl: string;
  destinationMapUrl: string;
  routeMapUrl: string;
}

export default function SetPricePage() {
  const router = useRouter();
  const { id } = useParams();
  const [booking, setBooking] = useState<Booking | null>(null);
  const [distance, setDistance] = useState<number | ''>('');
  const [price, setPrice] = useState<number | ''>('');
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [isBookingAccepted, setIsBookingAccepted] = useState(false);

  const fetchBookingDetails = async () => {
    try {
      const res = await silentAxios.get(`http://localhost:3001/booking/${id}`, {
        headers: {
          Authorization: `Bearer ${sessionStorage.getItem('token')}`,
        },
      });
      
      setBooking(res.data);
      
      if (res.data.status === 'Accepted') {
        setIsBookingAccepted(true);
        setDistance(res.data.distance || '');
        setPrice(res.data.price || '');
        setError('This booking has already been accepted');
      }
      
      setLoading(false);
    } catch (err: any) {
      setError('Could not fetch booking details');
      setLoading(false);
      if (!err.suppressLog) {
        console.error('Error fetching booking details:', err);
      }
    }
  };

  useEffect(() => {
    if (id) {
      fetchBookingDetails();
    }
  }, [id]);

  const handleDistanceChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const newDistance = e.target.value ? parseFloat(e.target.value) : '';
    setDistance(newDistance);

    if (newDistance !== '') {
      const calculatedPrice = newDistance * 20;
      setPrice(calculatedPrice);
    } else {
      setPrice('');
    }
  };

  const handleConfirmBooking = async () => {
    try {
      if (distance === '') {
        setError('Please enter a valid distance');
        return;
      }

      setLoading(true);
      setError('');

      const acceptResponse = await silentAxios.patch(
        `http://localhost:3001/booking/accept/${id}`,
        {},
        {
          headers: {
            Authorization: `Bearer ${sessionStorage.getItem('token')}`,
          },
        }
      );

      const priceResponse = await silentAxios.patch(
        `http://localhost:3001/booking/set-price/${id}`,
        { distance: distance },
        {
          headers: {
            Authorization: `Bearer ${sessionStorage.getItem('token')}`,
          },
        }
      );

      router.push('/PendingRequests');
    } catch (err: any) {
      if (axios.isAxiosError(err) && err.response?.status === 400) {
        setError(err.response?.data?.message || 'This car has already been booked');
        setIsBookingAccepted(true);
      } else {
        setError('The Car is Already Booked');
        if (!err.suppressLog) {
          console.error('Error confirming booking:', err);
        }
      }
    } finally {
      setLoading(false);
    }
  };

  const handleCancelBooking = () => {
    router.push('/PendingRequests');
  };

  return (
    <div className="min-h-screen bg-gradient-to-br from-gray-900 to-gray-800 text-white p-6">
      <div className="max-w-4xl mx-auto">
        <div className="flex items-center justify-between mb-8">
          <button
            onClick={handleCancelBooking}
            className="flex items-center gap-2 text-gray-300 hover:text-white transition-colors"
          >
            <FaArrowLeft /> Back to Requests
          </button>
          <h1 className="text-3xl font-bold bg-clip-text text-transparent bg-gradient-to-r from-cyan-400 to-blue-500">
            Booking Details
          </h1>
          <div className="w-10"></div>
        </div>

        {loading && (
          <div className="flex justify-center items-center h-64">
            <div className="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-blue-500"></div>
          </div>
        )}

        {error && (
          <div className="bg-red-900/50 border border-red-500 text-red-200 p-4 rounded-lg mb-6">
            {error}
          </div>
        )}

        {booking && (
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
            <div className="bg-gray-800/50 backdrop-blur-sm rounded-xl p-6 border border-gray-700 shadow-xl">
              <h2 className="text-xl font-semibold mb-4 text-cyan-400">Customer Information</h2>
              <div className="space-y-4">
                <div>
                  <p className="text-gray-400">Name</p>
                  <p className="text-lg font-medium">{booking.customerName}</p>
                </div>
                <div>
                  <p className="text-gray-400">Email</p>
                  <p className="text-lg font-medium">{booking.customerEmail}</p>
                </div>
              </div>
            </div>

            <div className="bg-gray-800/50 backdrop-blur-sm rounded-xl p-6 border border-gray-700 shadow-xl">
              <h2 className="text-xl font-semibold mb-4 text-cyan-400">Trip Details</h2>
              <div className="space-y-4">
                <div>
                  <p className="text-gray-400">Pickup Location</p>
                  <p className="text-lg font-medium">{booking.pickupLocation}</p>
                </div>
                <div>
                  <p className="text-gray-400">Destination</p>
                  <p className="text-lg font-medium">{booking.destinationLocation}</p>
                </div>
                <div className="flex gap-4 pt-2">
                  <a
                    href={booking.pickupMapUrl}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="flex items-center gap-2 text-blue-400 hover:text-blue-300 transition-colors"
                  >
                    <FaMapMarkerAlt /> View Pickup
                  </a>
                  <a
                    href={booking.destinationMapUrl}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="flex items-center gap-2 text-blue-400 hover:text-blue-300 transition-colors"
                  >
                    <FaMapMarkerAlt /> View Destination
                  </a>
                  <a
                    href={booking.routeMapUrl}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="flex items-center gap-2 text-purple-400 hover:text-purple-300 transition-colors"
                  >
                    <FaRoute /> View Route
                  </a>
                </div>
              </div>
            </div>

            <div className="bg-gray-800/50 backdrop-blur-sm rounded-xl p-6 border border-gray-700 shadow-xl lg:col-span-2">
              <h2 className="text-xl font-semibold mb-6 text-cyan-400">
                {isBookingAccepted ? 'Booking Details' : 'Set Pricing'}
              </h2>
              <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                <div>
                  <label className="block text-gray-400 mb-2">Distance (km)</label>
                  <input
                    type="number"
                    value={distance}
                    onChange={handleDistanceChange}
                    className={`w-full bg-gray-700/50 border border-gray-600 rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-cyan-500 focus:border-transparent ${
                      isBookingAccepted ? 'opacity-70 cursor-not-allowed' : ''
                    }`}
                    placeholder="Enter distance"
                    disabled={isBookingAccepted}
                  />
                </div>
                <div>
                  <label className="block text-gray-400 mb-2">Price (Taka)</label>
                  <input
                    type="number"
                    value={price}
                    onChange={(e) => setPrice(Number(e.target.value))}
                    className={`w-full bg-gray-700/50 border border-gray-600 rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-cyan-500 focus:border-transparent ${
                      isBookingAccepted ? 'opacity-70 cursor-not-allowed' : ''
                    }`}
                    disabled
                  />
                </div>
              </div>
              <div className="mt-8 flex justify-end gap-4">
                <button
                  onClick={handleCancelBooking}
                  className="flex items-center gap-2 px-6 py-3 bg-gray-700 hover:bg-gray-600 rounded-lg transition-colors"
                  disabled={loading}
                >
                  <FaTimes /> {isBookingAccepted ? 'Back' : 'Cancel'}
                </button>
                {!isBookingAccepted && (
                  <button
                    onClick={handleConfirmBooking}
                    className={`flex items-center gap-2 px-6 py-3 bg-gradient-to-r from-cyan-600 to-blue-600 hover:from-cyan-500 hover:to-blue-500 rounded-lg transition-colors ${
                      loading ? 'opacity-70 cursor-not-allowed' : ''
                    }`}
                    disabled={loading}
                  >
                    {loading ? (
                      <>
                        <svg className="animate-spin -ml-1 mr-2 h-4 w-4 text-white" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                          <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                          <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                        </svg>
                        Processing...
                      </>
                    ) : (
                      <>
                        <FaCheck /> Confirm Booking
                      </>
                    )}
                  </button>
                )}
              </div>
            </div>
          </div>
        )}
      </div>
    </div>
  );
}