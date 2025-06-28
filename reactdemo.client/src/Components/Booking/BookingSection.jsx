import React, { useState } from "react";
import CalendarContainer from './CalendarContainer';
import Coupon from './Coupon';
import DatePicker from './DatePicker';
import GuestsPicker from './GuestsPicker';
import '../../Styles/Booking/BookingSection.css';

function BookingSection() {
    const today = new Date();
    const tomorrow = new Date(new Date().setDate(today.getDate() + 1));
    const maxDate = new Date(new Date().setDate(today.getDate() + 180));
    const [startDate, setStartDate] = useState(new Date(today));
    const [endDate, setEndDate] = useState(new Date(tomorrow));
    const handleDateChange = (dateArray) => {
        setStartDate(dateArray[0]);
        setEndDate(dateArray[1]);
    }
  return (
      <section className="booking" >
          <div className="booking__pickers-container" >
              <GuestsPicker />
              <DatePicker type="check-in" date={startDate} />
              <DatePicker type="check-out" date={endDate} />
          </div>
          <div className="booking__content-container">
              <Coupon />
              <CalendarContainer handleDateChange={handleDateChange} minDate={today} maxDate={maxDate} startDate={startDate} endDate={endDate} />
          </div>
      </section>
  );
}

export default BookingSection;