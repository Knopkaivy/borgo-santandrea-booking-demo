import '../../Styles/Components/Cart/CartItem.css';
function CartItem({ cartItem, id, tax, handleRemoveRoom }) {
    const roomTotalString = cartItem.preTaxTotal.toLocaleString('en-US', {minimumFractionDigits: 2, maximumFractionDigits: 2});
    const taxString = (cartItem.preTaxTotal * tax).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });

    const handleClickRemove = () => {
        handleRemoveRoom(id);
    }

  return (
      <div className="cart-item" >
          <div className="cart-item__row" >
              <div className="cart-item__name" >{cartItem.name}</div>
              <div className="cart-item__price" >${roomTotalString}</div>
          </div>
          <p className="cart-item__description">Best available flexible rate</p>
          <div className="cart-item__row" >
              <div className="cart-item__name" >Taxes and fees</div>
              <div className="cart-item__price" >${taxString}</div>
          </div>
          <p className="cart-item__description">{cartItem.numberNights} Night stay</p>
          <p className="cart-item__description">{cartItem.startDate.toDateString()} - {cartItem.endDate.toDateString()}</p>
          <p className="cart-item__description" >{cartItem.adults} Adults, {cartItem.children} Children</p>
          <div className="cart-item__buttons-container" >
              <button className="cart-item__button--transparent" onClick={handleClickRemove}  >Remove</button>
          </div>
      </div>
  );
}

export default CartItem;