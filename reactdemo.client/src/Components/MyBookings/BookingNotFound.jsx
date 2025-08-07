import '../../Styles/MyBookings/BookingNotFound.css';
function BookingNotFound({ handleRefreshBookingList }) {
  return (
      <div className='booking-not-found' >
          <p>Booking not found</p>
          <button onClick={handleRefreshBookingList} >GO BACK</button>
      </div>
  );
}

export default BookingNotFound;