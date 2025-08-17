import { useState, useEffect } from 'react';
import { useNavigate, useParams, Link } from "react-router";
import AuthorizeView from '../Components/Authorize/AuthorizeView';
import BookingDetailItem from '../Components/MyBookings/BookingDetailItem';
import Navbar from '../Components/Navbar/Navbar';
import GuestInfo from '../Components/MyBookings/GuestInfo';
import '../Styles/Pages/BookingDetail.css';

function BookingDetail() {
    const navigate = useNavigate();
    const { id } = useParams();
    const [booking, setBooking] = useState(null);
    const [bookingTotal, setBookingTotal] = useState(0);

    const calculateTotal = (items) => {
        let total = 0;
        items.forEach(item => {
            const startDate = new Date(item.checkInDate);
            const endDate = new Date(item.checkOutDate);
            const numNights = Math.round(Math.abs(endDate.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24));
            total += (item.price * numNights * 1.1);
        })
        setBookingTotal(total);
    }

    const getBooking = () => {
        fetch(`get/${id}`)
            .then(results => {
                const res = results.json();
                return res;
            })
            .then(data => {
                setBooking(data);
                calculateTotal(data.rooms);
            })
    }

    useEffect(() => {
        getBooking();
    }, [])

    const handleRemoveItem = () => {

    }

    const deleteBooking = () => {
        fetch(`/booking/${id}/`, {
            method: 'DELETE',
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }

                if (response.status === 204) {
                    console.log('Resource deleted successfully (No Content)');
                }

                navigate(-1);
            })
            .catch(error => {
                console.error('There was a problem with the fetch operation:', error);
            });
    }

    const handleDeleteBooking = () => {
        deleteBooking();
    }

    return (
     <>
        <Navbar/>
            <div className='booking-detail'>
                {booking !== null &&
                    <div className='booking-detail__content'>
                            <GuestInfo first={booking.firstName} last={booking.lastName} email={booking.email} />
                        <div className="booking-detail__items-container" >
                            {booking.rooms.map((room, i) => {
                                return <BookingDetailItem key={i} item={room} id={i} handleRemoveItem={handleRemoveItem} isEdit={false} />
                            })}   
                        </div>
                    </div>
                }
                <div className="booking-detail__total-container" >
                    <div className='booking-detail__total' >
                        Total
                        ${Number(bookingTotal).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                    </div>
                    <p >Including taxes and fees</p>
                </div>
                <div className="booking-detail__buttons-container">
                    <AuthorizeView>
                        <Link to={`/booking/edit/${id}`} className='button booking-detail__button-link--blue' >EDIT</Link>
                    </AuthorizeView>
                    <button onClick={() => navigate(-1)} className='booking-detail__button-link--blue-light' >GO BACK</button>
                    <AuthorizeView>
                        <button onClick={handleDeleteBooking} >DELETE</button>
                    </AuthorizeView>
                </div>
            </div>
     </>
  );
}

export default BookingDetail;