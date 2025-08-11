import { useState, useEffect } from 'react';
import Navbar from '../Navbar/Navbar';
import BookingFound from '../MyBookings/BookingFound';
import AuthorizeView from '../Authorize/AuthorizeView';

import '../../Styles/Pages/AllBookings.css';
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

    const handleRefreshBookingList = () => {
        getBookings();
    }

    return (
        <>
            <Navbar />
            <main className='all-bookings' >
                <AuthorizeView>
                    <BookingFound bookings={bookings} handleRefreshBookingList={handleRefreshBookingList} />
                </AuthorizeView>
            </main>
        </>
    );
}

export default AllBookings;