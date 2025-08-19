import { useState, useEffect } from 'react';
import { useNavigate, useParams } from "react-router";
import BookingDetailItem from '../Components/MyBookings/BookingDetailItem';
import Navbar from '../Components/Navbar/Navbar';
import GuestInfo from '../Components/MyBookings/GuestInfo';
import '../Styles/Pages/BookingEdit.css';
function BookingEdit() {
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
        fetch(`/booking/detail/get/${id}`)
            .then(results => {
                const res = results.json();
                return res;
            })
            .then(data => {
                setBooking(data);
                calculateTotal(data.rooms);
            })
    }

    const updateBooking = () => {
        fetch(`/booking/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(booking)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Update failed');
                }

                return response.json();
            })
            .then(data => {
                navigate(`/booking/detail/${id}`);
            })
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

    useEffect(() => {
        getBooking();
    }, [])

    const handleRemoveItem = (id) => {
        let newItemList = [...booking.rooms];
        newItemList.splice(id, 1);
        setBooking(prevState => ({ ...prevState, rooms: newItemList }));
        calculateTotal(newItemList);
    }

    const handleUpdateBooking = () => {
        if (booking.rooms.length === 0) {
            deleteBooking();
        } else {
            updateBooking();
        }
    }

    const handleDeleteBooking = () => {
        deleteBooking();
    }

    return (
        <>
            <Navbar />
            <div className='booking-edit'>
                {booking !== null &&
                    <div className='booking-edit__content'>
                        <GuestInfo first={booking.firstName} last={booking.lastName} email={booking.email} />
                        <div className="booking-edit__items-container" >
                            {booking.rooms.map((room, i) => {
                                return <BookingDetailItem key={i} id={i} item={room} handleRemoveItem={handleRemoveItem} isEdit={true} />
                            })}
                        </div>
                    </div>
                }
                <div className="booking-edit__total-container" >
                    <div className='booking-edit__total' >
                        Total
                        ${Number(bookingTotal).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                    </div>
                    <p >Including taxes and fees</p>
                </div>
                <div className="button__container">
                    <button onClick={handleUpdateBooking} className='button--blue' >SAVE</button>
                    <button onClick={() => navigate(-1)} className='button--blue-light' >GO BACK</button>
                    <button onClick={handleDeleteBooking} >DELETE</button>
                </div>
            </div>
        </>
    );
}

export default BookingEdit;