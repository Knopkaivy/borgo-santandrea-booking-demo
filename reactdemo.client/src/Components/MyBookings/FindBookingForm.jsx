import { useState } from 'react';
import '../../Styles/Components/MyBookings/FindBookingForm.css';
function FindBookingForm({ handleGetBooking }) {

    const [confirmationNumber, setConfirmationNumber] = useState();
    const [confirmationEmail, setConfirmationEmail] = useState();

    const resetForm = () => {
        setConfirmationNumber('');
        setConfirmationEmail('');
    }

    const handleSubmitForm = (event) => {
        event.preventDefault();
        handleGetBooking(confirmationNumber, confirmationEmail);
        resetForm();
    }

  return (
      <form className='find-booking-form' onSubmit={(e) => handleSubmitForm(e)}>
          <h2 className='find-booking-form__heading'>With a number</h2>
              <div className='find-booking-form__input-field'>
                  <label htmlFor='find-booking-confirmation-number' className='find-booking-form__label' >
                  <span>Enter itinerary or confirmation number<span className='required' >*</span></span>
                  <input id='find-booking-confirmation-number' type='number' inputMode='numeric' required min={0} max={9999999999} value={confirmationNumber} onChange={(e) => setConfirmationNumber(e.target.value)} />
                  </label>
              </div>
              <div className='find-booking-form__input-field'>
                  <label htmlFor='find-booking-confirmation-email' className='find-booking-form__label' >
                      <span>Email Address<span className='required' >*</span></span>
                  <input id='find-booking-confirmation-email' type='email' required value={confirmationEmail} onChange={(e) => setConfirmationEmail(e.target.value)} />
                  </label>
              </div>
          <div className='button__container find-booking-form__button-container'>
              <input type='submit' className='button button--blue' value='SEARCH' />
              </div>
          <div>
              <p className='bold'>Don't know your itinerary or confirmation number?</p>
              <p>Your itinerary or confirmation number were included in an email sent at the time of booking. Please check your email to recover the number.</p>
          </div>
      </form>
  );
}

export default FindBookingForm;