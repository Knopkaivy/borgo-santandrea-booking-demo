import React, { useState } from 'react';
import CalendarIcon from '../Icons/CalendarIcon';
import '../../Styles/Booking/DatePicker.css';

function DatePicker({ type }) {
    const title = type === 'check-in' ? 'Check-in' : 'Check-out';
    let initialDate;
    const today = new Date();
    if (type === 'check-in') {
        initialDate = today.toLocaleDateString();
    } else {
        const tomorrow = new Date(today);
        tomorrow.setDate(today.getDate() + 1);
        initialDate = tomorrow.toLocaleDateString();
    }
    const [date, setDate] = useState(initialDate);
  return (
      <div className="date-picker" >
          <div className="date-picker__icon-container">
            <CalendarIcon/>
          </div>
          <div className="date-picker__description-container">
              <div className="date-picker__title">
                  {title}
              </div>
              <div className="date-picker__selected-value">
                  {date}
              </div>
          </div>
      </div>
  );
}

export default DatePicker;