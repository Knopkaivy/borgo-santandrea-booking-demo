import { useState, useEffect } from 'react';
import '../../Styles/Pages/BookingDetail.css';
import Navbar from '../Navbar/Navbar';
function BookingView() {
    const [booking, setBooking] = useState();

    //const getBooking = () => {
    //    fetch(`booking/${id}`)
    //        .then(results => {
    //            const res = results.json();
    //            return res;
    //        })
    //        .then(data => {
    //            setBooking(data);
    //        })
    //}

    //useEffect(() => {
    //    getBooking();
    //}, [])

    return (
     <>
        <Navbar/>
        <div className='booking-view'>Booking View</div>
     </>
  );
}

export default BookingView;