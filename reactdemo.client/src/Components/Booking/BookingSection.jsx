import CalendarContainer from './CalendarContainer';
import Coupon from './Coupon';
import DatePicker from './DatePicker';
import GuestsPicker from './GuestsPicker';
import '../../Styles/Booking/BookingSection.css';

function BookingSection({ startDate, endDate, maxDate, adults, children, handleDateChange, handleClickSearch, handleGuestsUpdate }) {
const today = new Date();
  return (
      <section className="booking" >
          <div className="booking__pickers-container" >
              <GuestsPicker adults={adults} children={children} handleGuestsUpdate={handleGuestsUpdate } />
              <DatePicker type="check-in" date={startDate} />
              <DatePicker type="check-out" date={endDate} />
          </div>
          <div className="booking__content-container">
              <Coupon />
              <CalendarContainer handleDateChange={handleDateChange} handleClickSearch={handleClickSearch} minDate={today} maxDate={maxDate} startDate={startDate} endDate={endDate} />
          </div>
      </section>
  );
}

export default BookingSection;