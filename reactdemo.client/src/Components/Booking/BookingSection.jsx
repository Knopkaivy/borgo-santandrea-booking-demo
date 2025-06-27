import CalendarContainer from './CalendarContainer';
import Coupon from './Coupon';
import DatePicker from './DatePicker';
import GuestsPicker from './GuestsPicker';
import '../../Styles/Booking/BookingSection.css';

function BookingSection() {
  return (
      <section className="booking" >
          <div className="booking__pickers-container" >
              <GuestsPicker />
              <DatePicker type="check-in" />
              <DatePicker type="check-out" />
          </div>
          <div className="booking__content-container">
              <Coupon />
              <CalendarContainer />
          </div>
      </section>
  );
}

export default BookingSection;