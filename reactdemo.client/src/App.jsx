import React, { useState, useEffect } from "react";
import AmenititesList from './Components/AmenititesList';
import BookingSection from './Components/Booking/BookingSection';
import Cart from './Components/Cart/Cart';
import Rooms from './Components/Rooms';
import Checkout from "./Components/Checkout/Checkout";
import './Styles/App.css';

function App() {
    const today = new Date();
    const tomorrow = new Date(new Date().setDate(today.getDate() + 1));
    const maxDate = new Date(new Date().setDate(today.getDate() + 180));
    const tax = .1;
    const [startDate, setStartDate] = useState(new Date(today));
    const [endDate, setEndDate] = useState(new Date(tomorrow));
    const [rooms, setRooms] = useState([]);
    const [adults, setAdults] = useState(2);
    const [children, setChildren] = useState(0);
    const [cartItems, setCartItems] = useState([]);
    const [cartTotal, setCartTotal] = useState(0);
    const [isCheckOut, setIsCheckOut] = useState(false);

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

    const postBooking = () => {

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

    const calculateCartTotal = (newCartItems) => {
        let total = 0;
        newCartItems.forEach(item => {
            total += item.preTaxTotal + item.preTaxTotal * tax;
        });
        return total;
    }

    const handleBookRoom = (price, name) => {
        const numberNights = Math.floor((endDate.getTime() - startDate.getTime()) / 86400000);
        const booking = {
            preTaxTotal: price * numberNights,
            startDate,
            endDate,
            numberNights,
            adults,
            children,
            name,
        }
        const newCartItems = [...cartItems, booking]
        setCartItems(newCartItems);
        setCartTotal(calculateCartTotal(newCartItems));
    }

    const handleRemoveRoom = (i) => {
        const newCartItems = [...cartItems];
        newCartItems.splice(i, 1);
        setCartItems(newCartItems);
        setCartTotal(calculateCartTotal(newCartItems));
    }

    const handleShowCheckOut = () => {
        setIsCheckOut(true);
    }

    const handleHideCheckOut = () => {
        setIsCheckOut(false);
    }

    const handlePostBooking = () => {

    }

    return (
        <main className="app__main" >
            <Checkout cartItems={cartItems} cartTotal={cartTotal} handleRemoveRoom={handleRemoveRoom} tax={tax} isCheckOut={isCheckOut} handleShowCheckOut={handleShowCheckOut} handleHideCheckOut={handleHideCheckOut} />
            <div className="app__content--left" >
                <BookingSection startDate={startDate} endDate={endDate} maxDate={maxDate} adults={adults} children={children} handleDateChange={handleDateChange} handleClickSearch={handleClickSearch} handleGuestsUpdate={handleGuestsUpdate } />
                <Rooms rooms={rooms} numberGuests={adults + children} handleBookRoom={handleBookRoom} />
            </div>
            <div className="app__content--right" >
                <Cart cartItems={cartItems} cartTotal={cartTotal} handleRemoveRoom={handleRemoveRoom} tax={tax} handleShowCheckOut={handleShowCheckOut} />
                <AmenititesList/>
            </div>
        </main>
    );
    
}

export default App;