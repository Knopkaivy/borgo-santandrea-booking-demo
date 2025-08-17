import ChevronDownIcon from "../Icons/ChevronDownIcon";
import '../../Styles/Components/Booking/Coupon.css';
import { useState } from "react";

function Coupon() {
    const promoTypes = ["Promo Code", "Group Code"];
    const [isExpanded, setIsExpanded] = useState(false);

    const handleToggleShowDetail = () => {
        setIsExpanded(!isExpanded);
    }

    const handleHideDetail = () => {
        setIsExpanded(false);
    }

    const handleApplyCode = () => {
        
    }
    return (
      <div className="coupon__wrapper" >
            <div className={`coupon ${isExpanded ? '' : 'up'}`} >
                <div className="coupon__title" onClick={handleToggleShowDetail} >
                  Special Codes or Rates
              </div>
              <ChevronDownIcon/>
            </div>
            <div className={`coupon__detail ${isExpanded ? '' : 'hide'}`} >
                <div className="coupon__entries-container">
                    <div className="coupon__promo-container" >
                        <div className="coupon__entry" >
                            <select className='coupon__select' name="promo-type" id="promo-type">
                                {promoTypes.map(option => (
                                    <option key={option} value={option}>
                                        {option}
                                    </option>
                                ))}
                            </select>
                        </div>
                        <div className="coupon__entry" >
                            <label htmlFor="promo-code" className='coupon__label' >
                                <span>Enter Code</span>
                                <input id="promo-code" type='text' />
                            </label>
                        </div>
                    </div>
                    <div>
                        <div className="coupon__entry" >
                            <label htmlFor="agent-id" className='coupon__label' >
                                <span>Agent ID</span>
                                <input id="agent-id" type='text' />
                            </label>
                        </div>
                    </div>
                </div>
                <div className='coupon__button-container' >
                    <button className="coupon__button--transparent" onClick={handleHideDetail} >Cancel</button>
                    <button className="coupon__button--blue" onClick={handleApplyCode} >APPLY</button>
                </div>
           </div>
      </div>
  );
}

export default Coupon;