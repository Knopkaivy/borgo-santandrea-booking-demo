import { useState, useEffect } from 'react';
import '../../Styles/MyBookings/FindBooking.css';
import Navbar from '../Navbar/Navbar';
import FindBookingForm from './FindBookingForm';
import FindBookingResult from './FindBookingResult';
function FindBooking() {

    const [bookings, setBookings] = useState([]);
    const [showResult, setShowResult] = useState(false);

    const getBooking = (bookingId, email) => {
        fetch(`booking/${bookingId}/${email}`)
            .then(results => {
                const res = results.json();
                return res;
            })
            .then(data => {
                setBookings(data);
            }).catch(e => {
                console.log(e);
            })
    }

    const handleGetBooking = (bookingId, email) => {
        getBooking(bookingId, email);
        setShowResult(true);
    }

    const handleRefreshBookingList = () => {
        setBookings([]);
        setShowResult(false);
    }


    return (
      <>
          <Navbar/>
            <main className='find-booking'>
                <div className='find-booking__content'>
                    <h1 className='find-booking__heading'>View, change, or cancel your reservation or order</h1>
                    <div className={`find-booking__forms-container ${showResult ? 'hide' : ''}`}>
                        <FindBookingForm handleGetBooking={handleGetBooking} />
                    </div>
                    <br/>
                    {showResult && <FindBookingResult bookings={bookings} handleRefreshBookingList={handleRefreshBookingList} />}
                </div>
            </main>
      </>
  );
}

export default FindBooking;