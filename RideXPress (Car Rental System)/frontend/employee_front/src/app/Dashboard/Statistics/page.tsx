'use client';
import { useEffect, useState } from 'react';

export default function StatisticsPage() {
  const [pdfUrl, setPdfUrl] = useState<string | null>(null);
  const [error, setError] = useState<string | null>(null); // Error state to store error messages

  useEffect(() => {
    const fetchPDF = async () => {
      try {
        // Make a GET request to fetch the PDF file from the backend
        const response = await fetch('http://localhost:3001/car/stats/pdf', {
          method: 'GET', // Ensure it's a GET request
          headers: {
            'Authorization': `Bearer ${sessionStorage.getItem('token')}`,
            'Content-Type': 'application/json',
          },
        });

        if (!response.ok) {
          // Check if the response is not OK (status code is not 2xx)
          setError(`Failed to fetch PDF. Status: ${response.status} ${response.statusText}`);
          throw new Error('Failed to fetch PDF');
        }

        const blob = await response.blob(); // Get the PDF as a Blob
        const url = window.URL.createObjectURL(blob); // Create a URL for the Blob
        setPdfUrl(url); // Set the PDF URL to display it
      } catch (error: any) {
        setError(`Error fetching PDF: ${error.message}`); // Set error message for frontend display
        console.error('Error fetching PDF:', error);
      }
    };

    fetchPDF(); // Call the function to fetch the PDF when the component mounts
  }, []); // Empty dependency array ensures it only runs once when the component is mounted

  return (
    <div className="h-screen bg-black text-white p-6">
      <h2 className="text-2xl font-bold text-center mb-6">Statistics</h2>
      
      {/* Display error message if there is an error */}
      {error && <p className="text-red-600 text-center">{error}</p>}

      {/* Show PDF if it's fetched successfully */}
      {pdfUrl ? (
        <embed
          src={pdfUrl} // PDF URL from the backend
          type="application/pdf"
          width="100%"
          height="100%"
        />
      ) : (
        <p className="text-center text-white">Loading PDF...</p>
      )}
    </div>
  );
}
