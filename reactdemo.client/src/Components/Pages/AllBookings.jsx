import { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar';
import '../../Styles/Pages/AllBookings.css';
import BookingFound from '../MyBookings/BookingFound';
function AllBookings() {
    const [bookings, setBookings] = useState([]);

    const getBookings = () => {
        fetch(`booking/`)
            .then(results => {
                const res = results.json();
                return res;
            })
            .then(data => {
                setBookings(data);
            })
    }

    useEffect(() => {
        getBookings();
    }, [])

    const handleGetAllBookings = () => {
        getBookings();
    }

    return (
        <>
            <Navbar />
            <main className='all-bookings' >
                <BookingFound bookings={bookings} handleGetAllBookings={handleGetAllBookings} />
            </main>
        </>
    );
}

export default AllBookings;