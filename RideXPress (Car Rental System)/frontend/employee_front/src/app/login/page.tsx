'use client';
import { useState, useEffect } from 'react';
import axios from 'axios';
import { useRouter } from 'next/navigation';
import Link from 'next/link';
import { FiEye, FiEyeOff } from 'react-icons/fi';

export default function LoginPage() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false);
  const [message, setMessage] = useState('');
  const [messageType, setMessageType] = useState<'error' | 'success'>('error');
  const [num1, setNum1] = useState(0);
  const [num2, setNum2] = useState(0);
  const [userAnswer, setUserAnswer] = useState('');
  const [isMounted, setIsMounted] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const router = useRouter();

  useEffect(() => {
    setIsMounted(true);
    generateNewCaptcha();
  }, []);

  const generateNewCaptcha = () => {
    setNum1(Math.floor(Math.random() * 10));
    setNum2(Math.floor(Math.random() * 10));
    setUserAnswer('');
  };

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();
    setMessage('');
    setIsLoading(true);

    // Client-side validation
    if (!email || !password) {
      setMessageType('error');
      setMessage('Email and password are required');
      setIsLoading(false);
      return;
    }

    if (parseInt(userAnswer) !== num1 + num2) {
      setMessageType('error');
      setMessage('CAPTCHA verification failed. Please try again.');
      generateNewCaptcha();
      setIsLoading(false);
      return;
    }

    try {
      const response = await axios.post('http://localhost:3001/authentication/login', {
        email,
        password,
      });

      const data = response.data;

      sessionStorage.setItem('token', data.loginToken);
      sessionStorage.setItem('email', email);
      generateNewCaptcha();
      
      
      setMessageType('success');
      setMessage('Login successful! ');
      
      
      setTimeout(() => {
        router.push('/Dashboard');
      }, 1000);
    } catch (error: any) {
      generateNewCaptcha();
      
      
      if (error.response) {
        setMessageType('error');
        setMessage(error.response.data.message || 'Invalid credentials');
      } else if (error.request) {
        setMessageType('error');
        setMessage('Network error. Please try again.');
      } else {
        setMessageType('error');
        setMessage('Something went wrong. Please try again.');
      }
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="relative min-h-screen flex items-center justify-center">
      <img
        src="/images/login-bg.jpg"
        alt="Background"
        className="absolute inset-0 w-full h-full object-cover z-0"
      />
      <div className="absolute inset-0 bg-gradient-to-r from-indigo-900 to-blue-900 opacity-70 z-10" />
      
      <div className="relative z-20 bg-white p-10 rounded-2xl shadow-2xl w-full max-w-md">
        <div className="text-center mb-6">
          <h1 className="text-4xl font-bold text-blue-700">RideXPress</h1>
          <p className="text-gray-600 mt-2">Welcome back! Please login to continue</p>
        </div>

        <form onSubmit={handleLogin} className="space-y-5">
          <div>
            <label className="block text-gray-700 font-semibold mb-1">Email</label>
            <input
              type="email"
              className="input input-bordered w-full"
              placeholder="you@example.com"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
          </div>

          <div className="relative">
            <label className="block text-gray-700 font-semibold mb-1">Password</label>
            <input
              type={showPassword ? "text" : "password"}
              className="input input-bordered w-full pr-10"
              placeholder="••••••••"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
            <button
              type="button"
              className="absolute right-3 top-9 text-gray-500 hover:text-gray-700"
              onClick={togglePasswordVisibility}
            >
              {showPassword ? (
                <FiEyeOff className="h-5 w-5" />
              ) : (
                <FiEye className="h-5 w-5" />
              )}
            </button>
          </div>

          {isMounted && (
            <div className="space-y-2">
              <div className="flex items-center justify-between">
                <label className="block text-gray-700 font-semibold mb-1">
                  CAPTCHA: What is {num1} + {num2}?
                </label>
                <button 
                  type="button" 
                  onClick={generateNewCaptcha}
                  className="text-sm text-blue-500 hover:underline"
                >
                  Refresh
                </button>
              </div>
              <input
                type="number"
                className="input input-bordered w-full"
                placeholder="Enter answer"
                value={userAnswer}
                onChange={(e) => setUserAnswer(e.target.value)}
                required
              />
            </div>
          )}

          <button 
            type="submit" 
            className="btn btn-primary w-full"
            disabled={isLoading}
          >
            {isLoading ? 'Logging in...' : 'Login'}
          </button>

          {message && (
            <p className={`text-center text-sm ${
              messageType === 'error' ? 'text-red-600' : 'text-green-600'
            }`}>
              {message}
            </p>
          )}
        </form>

        <div className="text-center mt-6 space-y-2">
          <p className="text-sm text-black">
            Don't have an account?{' '}
            <Link href="/Registration" className="text-blue-500 hover:underline">
              Register
            </Link>
          </p>
          <p className="text-sm text-black">
            Forgot password?{' '}
            <button 
              onClick={() => router.push('/ForgetPassword')}
              className="text-blue-500 hover:underline bg-transparent border-none p-0 cursor-pointer"
            >
              Reset
            </button>
          </p>
        </div>
      </div>
    </div>
  );
}