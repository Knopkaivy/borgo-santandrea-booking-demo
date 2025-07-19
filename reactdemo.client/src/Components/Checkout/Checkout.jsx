import React, { useState } from "react";
import CartItem from '../Cart/CartItem';
import GuestCheckoutForm from "./GuestCheckoutForm";
import '../../Styles/Checkout/Checkout.css';
function Checkout({ cartItems, cartTotal, tax, handleRemoveRoom, isCheckOut, handleHideCheckOut }) {

    const [isConfirmation, setIsConfirmation] = useState(false);

    const handleShowConfirmation = () => {
        setIsConfirmation(true);
    }

    const handleHideConfirmation = () => {
        setIsConfirmation(false);
    }

    const handleClickCancel = () => {
        handleHideCheckOut();
        setIsConfirmation(false);
    }

  return (
      <div className={`checkout ${isCheckOut ? '' : 'hide'}`} >
          <div className="checkout__overlay" ></div>
          <div className="checkout__modal" >
              <div className={`checkout__content ${isConfirmation ? 'hide' : ''}`}>
                  <div className="checkout__detail" >
                      <GuestCheckoutForm/>
                      <div className="checkout__cart-items-container" >
                          {cartItems.map((cartItem, i) => {
                              return <CartItem key={i} cartItem={cartItem} id={i} tax={tax} handleRemoveRoom={handleRemoveRoom} />
                          })}
                      </div>
                  </div>
                  <div className="checkout__total-container" >
                      <div className='checkout__total' >Total ${Number(cartTotal).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                      </div>
                      <p className={`${cartItems.length === 0 ? 'hide' : ''}`} >Including taxes and fees</p>
                  </div>
              </div>
              <div className={`checkout__confirmation ${isConfirmation ? '' : 'hide'}`}>
                  <div className="checkout__confirmation-header" >Confirmation</div>
                  <p className="checkout__confirmation-thankyou" >Thank you for booking with Borgo Santandrea.</p>
                  <p>This website is created for demo purposes only. No actual payment will be collected.</p>
              </div>
                <div className='checkout__buttons-container' >
                    <button className="checkout__button--transparent" onClick={handleClickCancel} >Cancel</button>
                  <button className={`checkout__button--blue ${isConfirmation ? 'hide' : ''}`} onClick={handleShowConfirmation} >PROCESS PAYMENT</button>
                  <button className={`checkout__button--blue ${isConfirmation ? '' : 'hide'}`} onClick={handleHideConfirmation} >GO BACK</button>
                </div>
          </div>
      </div>
  );
}

export default Checkout;