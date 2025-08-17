import { useState } from 'react';
import '../../Styles/Components/Booking/ChildAgeSelector.css';
function ChildAgeSelector({ index }) {

    const ages = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
    const [selectedAge, setSelectedAge] = useState(0);

    const handleAgeChange = (event) => {
        setSelectedAge(Number(event.target.value));
    }
  return (
      <div className='child-age' >
          <label htmlFor={`selector-${index}`} className='child-age__label' >
              <span>Child {index + 1} Age<sup className='required' >*</sup></span>
              <select className='child-age__select' name={`selector-${index}`} id={`selector-${index}`} onChange={handleAgeChange} value={selectedAge}>
                  {ages.map(option => (
                      <option key={option} value={option}>
                          {option}
                      </option>
                  ))}
              </select>
          </label>
      </div>
  );
}

export default ChildAgeSelector;