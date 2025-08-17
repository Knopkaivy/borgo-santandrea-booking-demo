import BookingListItem from './BookingListItem';
import '../../Styles/Components/MyBookings/BookingFound.css';

function BookingFound({ bookings, handleRefreshBookingList }) {
  return (
      <div className='booking-found'>
          <div className='booking-found__header'>
              <div className='booking-found__header-item'>Confirmation</div>
              <div className='booking-found__header-item'>Email</div>
              <div className='booking-found__header-item'>Name</div>
              <div className='booking-found__header-item'></div>
          </div>
          <ul className='booking-found__list' >
              {bookings.map(booking => {
                  return <BookingListItem key={booking.bookingId} booking={booking} handleRefreshBookingList={handleRefreshBookingList } />
              }) }
          
          </ul>
      </div>
  );
}

export default BookingFound;