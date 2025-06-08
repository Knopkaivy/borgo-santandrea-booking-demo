import React, { useState, useEffect } from 'react';
import Room from './Room';
import RoomsImagesArray from './RoomsImages';
import '../Styles/Rooms.css';

const Rooms = () => {

    const [rooms, setRooms] = useState([]);

    useEffect(() => {
        fetch(`room`)
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