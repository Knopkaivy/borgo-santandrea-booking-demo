import CartItem from './CartItem';
import '../../Styles/Components/Cart/Cart.css';
function Cart({ cartItems, cartTotal, tax, handleRemoveRoom, handleShowCheckOut }) {
  return (
      <div className='cart' >
          <div className='cart__items-count' >Your Cart: {cartItems.length} Item{cartItems.length === 1 ? '' : 's'}</div>
          <div className="cart__detail" >
              <div className='cart__total' >Total ${Number(cartTotal).toLocaleString('en-US', {minimumFractionDigits: 2, maximumFractionDigits: 2})}
              </div>
              <p className={`${cartItems.length === 0 ? 'hide' : ''}`} >Including taxes and fees</p>
              <div className="cart__cart-items-container" >
                  {cartItems.map((cartItem, i) => {
                      return <CartItem key={i} cartItem={cartItem} id={i} tax={tax} handleRemoveRoom={handleRemoveRoom} />
                  })}
              </div>
          </div>
          <button className={`cart__button cart-button--checkout ${cartItems.length === 0 ? 'hide' : ''}`} onClick={handleShowCheckOut} >CHECKOUT</button>
      </div>
  );
}

export default Cart;