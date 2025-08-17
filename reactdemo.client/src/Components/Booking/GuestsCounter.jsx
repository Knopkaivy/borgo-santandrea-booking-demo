import React, { useState } from 'react';
import MinusIcon from '../Icons/MinusIcon';
import PlusIcon from '../Icons/PlusIcon';
import '../../Styles/Components/Booking/GuestsCounter.css';

function GuestsCounter({ type, count, maxNum, handleCounterUpdate }) {
    const title = type === 'adults' ? 'Adults (Ages 18 or above)' : 'Children (Ages 0-17)';

    const handleKeyPress = (event) => {
        event.preventDefault();
    }

    const handleInputChange = (event) => {
        handleCounterUpdate(event.target.value, type);
    };

    const increment = () => {
        if (count < maxNum) {
            handleCounterUpdate(count + 1, type);
        }
    };

    const decrement = () => {
        if (count > 0) {
            handleCounterUpdate(count - 1, type);
        }
    };

  return (
      <div className='guests-counter' >
          <label htmlFor={`counter-${type}`} className='guests-counter__label' >
            <span>{title}</span>
              <input id={`counter-${type}`} type='number' inputMode='numeric' value={count} min='0' max={maxNum} onChange={handleInputChange} onKeyPress={handleKeyPress} />
          </label>
          <div className='guests-counter__button-container' >
              <button className='guests-counter__button guests-counter__button--subtract' onClick={decrement} ><MinusIcon/></button>
              <button className='guests-counter__button guests-counter__button--add' onClick={increment} ><PlusIcon/></button>
          </div>
      </div>
  );
}

export default GuestsCounter;