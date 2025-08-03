import BookingFound from './BookingFound';
import BookingNotFound from './BookingNotFound';
import '../../Styles/MyBookings/FindBookingResult.css';
function FindBookingResult({ bookings, handleResetFindBooking }) {
  return (
      <div className='find-booking-result'>
          {
              bookings.length > 0 ?
                  <BookingFound bookings={bookings} />
                  :
                  <BookingNotFound handleResetFindBooking={handleResetFindBooking} />
          }
      </div>
  );
}

export default FindBookingResult;