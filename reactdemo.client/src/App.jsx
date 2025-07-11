import React, { useState, useEffect } from "react";
import AmenititesList from './Components/AmenititesList';
import BookingSection from './Components/Booking/BookingSection';
import Cart from './Components/Cart';
import Rooms from './Components/Rooms';
import './Styles/App.css';

function App() {
    const today = new Date();
    const tomorrow = new Date(new Date().setDate(today.getDate() + 1));
    const maxDate = new Date(new Date().setDate(today.getDate() + 180));
    const [startDate, setStartDate] = useState(new Date(today));
    const [endDate, setEndDate] = useState(new Date(tomorrow));
    const [rooms, setRooms] = useState([]);
    const [adults, setAdults] = useState(2);
    const [children, setChildren] = useState(0);

    const getRooms = (start, end) => {
        const startDateString = start.toISOString().split('T')[0];
        const endDateString = end.toISOString().split('T')[0];
        const numberGuests = adults + children;
        fetch(`room/${startDateString}/${endDateString}/${numberGuests}`)
            .then(results => {
                const res = results.json();
                return res;
            })
            .then(data => {
                setRooms(data);
            })
    }

    useEffect(() => {
        getRooms(startDate, endDate);
    }, [])

    const handleDateChange = (dateArray) => {
        setStartDate(dateArray[0]);
        setEndDate(dateArray[1]);
    }

    const handleClickSearch = () => {
        getRooms(startDate, endDate);
    }

    const handleGuestsUpdate = (adultsCounter, childrenCounter) => {
        setAdults(adultsCounter);
        setChildren(childrenCounter);
    }

    return (
        <main className="app__main" >
            <div className="app__content--left" >
                <BookingSection startDate={startDate} endDate={endDate} maxDate={maxDate} adults={adults} children={children} handleDateChange={handleDateChange} handleClickSearch={handleClickSearch} handleGuestsUpdate={handleGuestsUpdate } />
                <Rooms rooms={rooms} numberGuests={adults + children} />
            </div>
            <div className="app__content--right" >
                <Cart/>
                <AmenititesList/>
            </div>
        </main>
    );
    
}

export default App;