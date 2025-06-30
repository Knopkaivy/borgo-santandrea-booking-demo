import React, { useState } from 'react';
import '../Styles/Cart.css';
function Cart() {
    const [itemNumber, setItemNumber] = useState(0);
    const [total, setTotal] = useState(0);
  return (
      <div className='cart' >
          <div className='cart__items' >Your Cart: {itemNumber} Items</div>
          <div>
              <div className='cart__total' >Total ${total.toFixed(2)}</div>
              <p className={`${itemNumber === 0 ? 'hide' : ''}`} >Including taxes and fees</p>
          </div>
          <button className={`cart__button cart-button--add-room ${itemNumber === 0 ? 'hide' : ''}`} >ADD A ROOM</button>
          <button className={`cart__button cart-button--checkout ${itemNumber === 0 ? 'hide' : ''}`}>CHECKOUT</button>
      </div>
  );
}

export default Cart;