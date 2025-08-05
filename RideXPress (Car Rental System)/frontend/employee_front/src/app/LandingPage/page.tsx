'use client';
import { useRouter } from 'next/navigation';

export default function LandingPage() {
  const router = useRouter();

  return (
    <div className="min-h-screen bg-gray-900 text-white flex flex-col">
      {/* Hero Section */}
      <header className="relative bg-gradient-to-r from-black-600 to-blue-500 py-20 px-8 text-center">
        <img
          src="/images/hero-car.jpg"
          alt="Hero Car"
          className="absolute inset-0 object-cover w-full h-full opacity-20"
        />
        <div className="relative z-10">
           <h1 className="text-5xl md:text-6xl font-extrabold mb-4">RideXPress</h1> 
          <h2 className="text-5xl md:text-6xl font-extrabold mb-4">Drive in Style, Comfort, and Confidence</h2>
          <p className="text-lg md:text-xl max-w-2xl mx-auto mb-6">
            Discover a seamless way to rent premium and economy cars across the country.
          </p>
          <button
            onClick={() => router.push('/login')}
            className="btn btn-primary px-6 py-3 text-lg rounded-full"
          >
            Book Now
          </button>
        </div>
      </header>

      {/* Fleet Showcase */}
      <section className="py-20 px-6 bg-black">
        <div className="max-w-6xl mx-auto text-center">
          <h2 className="text-4xl font-bold mb-10">Explore Our Top Picks</h2>
          <div className="grid md:grid-cols-3 gap-6">
            <div className="bg-gray-800 rounded-lg overflow-hidden shadow">
              <img src="/images/sedan.jpg" alt="Sedan" className="w-full h-48 object-cover" />
              <div className="p-4">
                <h3 className="text-xl font-bold mb-2">Luxury Sedans</h3>
                <p>Smooth ride for business or leisure trips.</p>
              </div>
            </div>
            <div className="bg-gray-800 rounded-lg overflow-hidden shadow">
              <img src="/images/suv.jpg" alt="SUV" className="w-full h-48 object-cover" />
              <div className="p-4">
                <h3 className="text-xl font-bold mb-2">Family SUVs</h3>
                <p>Spacious and powerful, perfect for long drives.</p>
              </div>
            </div>
            <div className="bg-gray-800 rounded-lg overflow-hidden shadow">
              <img src="/images/economy.jpg" alt="Economy Car" className="w-full h-48 object-cover" />
              <div className="p-4">
                <h3 className="text-xl font-bold mb-2">Economy Cars</h3>
                <p>Affordable and fuel-efficient for daily travel.</p>
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* Testimonials */}
      <section className="py-20 px-6 bg-gray-900">
        <div className="max-w-5xl mx-auto text-center">
          <h2 className="text-3xl font-bold mb-8">Our Happy Customers</h2>
          <div className="grid md:grid-cols-2 gap-6">
            <div className="bg-gray-800 p-6 rounded-lg shadow">
              <p className="italic">"Flawless experience. The car was in excellent condition and the process was so simple!"</p>
              <span className="block mt-4 font-bold">— Abdul Aziz</span>
            </div>
            <div className="bg-gray-800 p-6 rounded-lg shadow">
              <p className="italic">"Highly recommend! We booked a luxury SUV for a weekend getaway—loved it!"</p>
              <span className="block mt-4 font-bold">— Abdullah Shafi</span>
            </div>
          </div>
        </div>
      </section>

      {/* CTA */}
      <footer className="bg-blue-700 py-12 text-center">
        <h3 className="text-3xl font-semibold mb-4">Start Your Journey with Us</h3>
        <button
          onClick={() => router.push('/login')}
          className="btn btn-accent px-8 py-3 text-lg"
        >
          Sign In to Book Now
        </button>
      </footer>
    </div>
  );
}
