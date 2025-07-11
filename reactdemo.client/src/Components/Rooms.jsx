import React, { useState, useEffect } from 'react';
import Room from './Room';
import RoomsImagesArray from './RoomsImages';
import '../Styles/Rooms.css';

const Rooms = () => {

    const today = new Date();
    const maxDate = new Date(new Date().setDate(today.getDate() + 180));
    const [rooms, setRooms] = useState([]);

    useEffect(() => {
        fetch(`room/${today.toISOString().split('T')[0]}/${maxDate.toISOString().split('T')[0] }`)
            .then(results => {
                const res = results.json();
                return res;
            })
            .then(data => {
                setRooms(data);
            })
    },[])

    return (
        <section className="rooms">
            <h1 className="rooms__header" >SELECT A ROOM</h1>
            <div className="rooms__filters-container" >
                Filters go here
            </div>
            {
                (rooms !== null) ? rooms.map(room => <Room key={room.id} room={room} imgSrc={RoomsImagesArray.find(img => img.id === room.imageId)?.image }  />) : <div>Loading data...</div>
            }
        </section>
    );
}

export default Rooms;