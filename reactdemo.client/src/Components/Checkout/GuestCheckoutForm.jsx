import '../../Styles/Checkout/GuestCheckoutForm.css';
function GuestCheckoutForm() {
    return (
        <div className="guest-checkout">
          <div className="guest-checkout__contact-header">Contact Information</div>
          <form className="guest-checkout__form" >
              <div className='guest-checkout__field' >
                  <label htmlFor="guest-checkout-first-name" className='guest-checkout__label' >
                      <span>First Name</span>
                      <input id="guest-checkout-first-name"/>
                  </label>
              </div>
              <div className='guest-checkout__field' >
                  <label htmlFor="guest-checkout-last-name" className='guest-checkout__label' >
                      <span>Last Name</span>
                      <input id="guest-checkout-last-name"/>
                  </label>
              </div>
              <div className='guest-checkout__field' >
                  <label htmlFor="guest-checkout-email" className='guest-checkout__label' >
                      <span>Email*</span>
                      <input id="guest-checkout-email" type="email" required />
                  </label>
              </div>
          </form>
      </div>
  );
}

export default GuestCheckoutForm;