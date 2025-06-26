import GuestsPicker from './GuestsPicker';
import DatePicker from './DatePicker';
import Coupon from './Coupon';
import '../../Styles/Booking/BookingSection.css';

function BookingSection() {
  return (
      <section className="booking" >
          <div className="booking__picers-container" >
              <GuestsPicker />
              <DatePicker type="check-in" />
              <DatePicker type="check-out" />
          </div>
          <div className="booking__coupon-container">
                <Coupon/>
          </div>
      </section>
  );
}

export default BookingSection;