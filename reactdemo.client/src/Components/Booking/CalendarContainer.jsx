import React, { useState } from "react";
import Calendar from 'react-calendar';
import '../../Styles/Booking/CalendarContainer.css';
import 'react-calendar/dist/Calendar.css';



function CalendarContainer({ minDate, maxDate, startDate, endDate, handleDateChange}) {

  return (
      <div className='calendar-container' >
          <p className='calendar-container__disclaimer' >We're showing the best available price per room for 1 night, based on the number of guests.</p>
          <Calendar
              onChange={handleDateChange}
              value={[startDate, endDate]}
              showDoubleView={true}
              minDate={minDate}
              maxDate={maxDate}
              selectRange={true}
              next2Label={null}
              prev2Label={null}
          />
          <p className='calendar-container__warning' ><span className='bold' >Warning</span> goes here</p>
          <div className='calendar-container__buttons-container' >
              <button className="calendar-container__button--transparent" >Cancel</button>
              <button className="calendar-container__button--blue" >SEARCH</button>
          </div>
      </div>
  );
}

export default CalendarContainer;