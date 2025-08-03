import '../../Styles/MyBookings/BookingNotFound.css';
function BookingNotFound({ handleResetFindBooking }) {
  return (
      <div className='booking-not-found' >
          <p>Booking not found</p>
          <button onClick={handleResetFindBooking} >GO BACK</button>
      </div>
  );
}

export default BookingNotFound;