import BookingFound from './BookingFound';
import BookingNotFound from './BookingNotFound';
import '../../Styles/Components/MyBookings/FindBookingResult.css';
function FindBookingResult({ bookings, handleRefreshBookingList }) {
  return (
      <div className='find-booking-result'>
          {
              bookings.length > 0 ?
                  <BookingFound bookings={bookings} handleRefreshBookingList={handleRefreshBookingList} />
                  :
                  <BookingNotFound handleRefreshBookingList={handleRefreshBookingList} />
          }
      </div>
  );
}

export default FindBookingResult;