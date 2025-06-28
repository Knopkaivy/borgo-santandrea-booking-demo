import CalendarIcon from '../Icons/CalendarIcon';
import '../../Styles/Booking/DatePicker.css';

function DatePicker({ date, type }) {
    const title = type === 'check-in' ? 'Check-in' : 'Check-out';

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
                  {date.toLocaleDateString()}
              </div>
          </div>
      </div>
  );
}

export default DatePicker;