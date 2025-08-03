import { Link } from "react-router";
import '../../Styles/MyBookings/BookingListItem.css';
function BookingListItem({ booking, handleGetAllBookings }) {
    const { bookingId, email, firstName, lastName } = booking;

    const deleteBooking = () => {
        fetch(`booking/${bookingId}/`, {
            method: 'DELETE',
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }

                if (response.status === 204) {
                    console.log('Resource deleted successfully (No Content)');
                }

                handleGetAllBookings();
            })
            .catch(error => {
                console.error('There was a problem with the fetch operation:', error);
            });
    }

    const handleDeleteBooking = () => {
        deleteBooking();
    }
  return (
      <li className='booking-list-item'>
          <div className='booking-list-item__subitem'>{bookingId}</div>
          <div className='booking-list-item__subitem'>{email}</div>
          <div className='booking-list-item__subitem'>{firstName} {lastName}</div>
          <div className='booking-list-item__subitem booking-list-item__subitem--button-container'>
              <Link to={`/booking-detail/${booking.bookingId}`} className='button booking-list-item__button-link' >VIEW</Link>
              <button className='booking-list-item__button--blue-light' >EDIT</button>
              <button onClick={handleDeleteBooking} >DELETE</button>
          </div>
      </li>
  );
}

export default BookingListItem;