import { useState } from 'react';
import CalendarContainer from './CalendarContainer';
import Coupon from './Coupon';
import DatePicker from './DatePicker';
import GuestsPicker from './GuestsPicker';
import '../../Styles/Components/Booking/BookingSection.css';

function BookingSection({ startDate, endDate, maxDate, adults, children, handleDateChange, handleClickSearch, handleGuestsUpdate }) {
    const today = new Date();
    const [isExpanded, setIsExpanded] = useState(false);

    const handleShowCalendar = () => {
        setIsExpanded(true);
    };

    const handleHideCalendar = () => {
        setIsExpanded(false);
    }

  return (
      <section className="booking" >
          <div className="booking__pickers-container" >
              <GuestsPicker adults={adults} children={children} handleGuestsUpdate={handleGuestsUpdate } />
              <DatePicker type="check-in" date={startDate} handleShowCalendar={handleShowCalendar} />
              <DatePicker type="check-out" date={endDate} handleShowCalendar={handleShowCalendar} />
          </div>
          <div className="booking__content-container">
              <Coupon />
              <CalendarContainer handleDateChange={handleDateChange} handleClickSearch={handleClickSearch} handleHideCalendar={handleHideCalendar} isExpanded={isExpanded} minDate={today} maxDate={maxDate} startDate={startDate} endDate={endDate} />
          </div>
      </section>
  );
}

export default BookingSection;