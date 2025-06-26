import React, { useState } from 'react';
import GuestsCounter from './GuestsCounter';
import ChildAgeSelector from './ChildAgeSelector';
import PersonIcon from '../Icons/PersonIcon';
import CloseIcon from '../Icons/CloseIcon';
import '../../Styles/Booking/GuestsPicker.css';

function GuestsPicker() {
    const [isActive, setIsActive] = useState(false);
    const [adults, setAdults] = useState(2);
    const [children, setChildren] = useState(0);
    const [adultsCounter, setAdultsCounter] = useState(adults);
    const [childrenCounter, setChildrenCounter] = useState(children);
    const [childAgeArray, setChildAgeArray] = useState([]);

    const handleCounterUpdate = (newCount, counterType) => {
        if (counterType === 'adults') {
            setAdultsCounter(newCount);
        } else {
            if (childrenCounter < newCount) {
                addChildAgeItem();
            } else if (childrenCounter > newCount) {
                removeChildAgeItem();
            }
            setChildrenCounter(newCount);
        }
    }

    const openPicker = () => {
        setIsActive(true);
    }

    const closePicker = () => {
        setIsActive(false);
    }

    const handleGuestsUpdate = () => {
        setAdults(adultsCounter);
        setChildren(childrenCounter);
        closePicker();
    }

    const addChildAgeItem = () => {
        setChildAgeArray([...childAgeArray, childAgeArray.length])
    }

    const removeChildAgeItem = () => {
        setChildAgeArray([...childAgeArray.slice(0, -1)]);
    }

  return (
      <div className="guests-picker" >
          <div className="guests-picker__display" onClick={openPicker} >
              <div className="guests-picker__icon-container">
                  <PersonIcon/>
              </div>
              <div className="guests-picker__description-container">
                  <div className="guests-picker__title">
                      Guests
                  </div>
                  <div className="guests-picker__selected-value">
                      {adults} adult{adults === 1 ? '' : 's'}, {children} {children === 1 ? 'child' : 'children'}
                  </div>
              </div>
          </div>
          <div className={`guests-picker__interaction-container ${isActive ? '' : 'hide'}`} >
              <button className="guests-picker__button--close" onClick={handleGuestsUpdate}  ><CloseIcon/></button>
              <div className="guests-picker__interaction-title">
                    GUESTS
              </div>
              <GuestsCounter type='adults' count={adultsCounter} maxNum='19' handleCounterUpdate={handleCounterUpdate} />
              <GuestsCounter type='children' count={childrenCounter} maxNum='18' handleCounterUpdate={handleCounterUpdate} />
              {childAgeArray.map(i => <ChildAgeSelector key={i} index={i} />)}
              <button className="guests-picker__button--done" onClick={handleGuestsUpdate} >DONE</button>
          </div>
      </div>
  );
}

export default GuestsPicker;