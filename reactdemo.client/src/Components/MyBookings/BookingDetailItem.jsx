import '../../Styles/Components/MyBookings/BookingDetailItem.css';

function BookingDetailItem({ id, item, isEdit, handleRemoveItem }) {
    const startDate = new Date(item.checkInDate);
    const endDate = new Date(item.checkOutDate);
    const numNights = Math.round(Math.abs(endDate.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24));
    const itemTotal = item.price * numNights;
    const taxTotal = itemTotal * .1;
  return (
      <div className='booking-detail-item' >
          <div className="booking-detail-item__row" >
              <div className="booking-detail-item__name" >{item.name}</div>
              <div className="booking-detail-item__price" >{itemTotal.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</div>
          </div>
          <p className="booking-detail-item__description">Best available flexible rate</p>
          <div className="booking-detail-item__row" >
              <div className="booking-detail-item__name" >Taxes and fees</div>
              <div className="booking-detail-item__price" >{taxTotal.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</div>
          </div>
          <p className="booking-detail-item__description">{numNights} Night stay</p>
          <p className="booking-detail-item__description">{startDate.toDateString()} - {endDate.toDateString()}</p>
          <p className="booking-detail-item__description" >{item.numberAdults} Adults, {item.numberChildren} Children</p>
          <div className={`button__container ${isEdit ? '' : 'hide'}`} >
              <button className='button--transparent booking-detail-item__button--transparent' onClick={() => handleRemoveItem(id) } >Remove</button>
          </div>
      </div>
  );
}

export default BookingDetailItem;