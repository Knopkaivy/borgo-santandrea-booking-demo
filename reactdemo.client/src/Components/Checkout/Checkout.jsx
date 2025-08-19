import React, { useState } from "react";
import CartItem from '../Cart/CartItem';
import GuestCheckoutForm from "./GuestCheckoutForm";
import '../../Styles/Components/Checkout/Checkout.css';

function Checkout({ cartItems, cartTotal, tax, isBookingSuccessful, confirmationNumber, handleRemoveRoom, isCheckOut, handleHideCheckOut, handlePostBooking }) {

    const [isConfirmation, setIsConfirmation] = useState(false);
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');

    const handleShowConfirmation = () => {
        handlePostBooking(firstName, lastName, email);
        setIsConfirmation(true);
    }

    const handleCloseCheckOut = () => {
        handleHideCheckOut();
        setIsConfirmation(false);
    }

    const handleClickCancel = () => {
        handleHideCheckOut();
        setIsConfirmation(false);
    }

    const handleUpdateFirstName = (value) => {
        setFirstName(value);
    }

    const handleUpdateLastName = (value) => {
        setLastName(value);
    }

    const handleUpdateEmail = (value) => {
        setEmail(value);
    }

  return (
      <div className={`checkout ${isCheckOut ? '' : 'hide'}`} >
          <div className="checkout__overlay" ></div>
          <div className="checkout__modal" >
              <div className={`checkout__content ${isConfirmation ? 'hide' : ''}`}>
                  <div className="checkout__detail" >
                      <GuestCheckoutForm handleUpdateFirstName={handleUpdateFirstName} handleUpdateLastName={handleUpdateLastName} handleUpdateEmail={handleUpdateEmail} />
                      <div className="checkout__cart-items-container" >
                          {cartItems.map((cartItem, i) => {
                              return <CartItem key={i} cartItem={cartItem} id={i} tax={tax} handleRemoveRoom={handleRemoveRoom} />
                          })}
                      </div>
                  </div>
                  <div className="checkout__total-container" >
                      <div className='checkout__total' >
                          Total ${Number(cartTotal).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </div>
                      <p className={`${cartItems.length === 0 ? 'hide' : ''}`} >Including taxes and fees</p>
                  </div>
              </div>
              <div className={`checkout__confirmation ${isConfirmation ? '' : 'hide'}`}>
                  <div className={`${isBookingSuccessful ? '' : 'hide'}`} >
                      <div className="checkout__confirmation-header" >Confirmation</div>
                      <p className="checkout__confirmation-thankyou" >Thank you for booking with Borgo Santandrea.</p>
                      <p>Please save this confirmation number for future reference - <span className='bold' >{confirmationNumber}</span></p>
                      <br/>
                      <p>This website is created for demo purposes only. No actual services will be provided and no payment will be collected.</p>
                  </div>
                  <div className={`${isBookingSuccessful ? 'hide' : ''}`}>
                      <p className="checkout__confirmation-thankyou" >At least one of the rooms that you trying to book is no longer available. Please refresh your search.</p>
                  </div>
              </div>
              <div className='button__container checkout__button-container' >
                  <button className={`button--transparent ${isConfirmation ? 'hide' : ''}`} onClick={handleClickCancel} >Cancel</button>
                  <button className={`button--blue ${isConfirmation ? 'hide' : ''}`} onClick={handleShowConfirmation} >PROCESS PAYMENT</button>
                  <button className={`button--blue ${isConfirmation ? '' : 'hide'}`} onClick={handleCloseCheckOut} >CLOSE</button>
                </div>
          </div>
      </div>
  );
}

export default Checkout;