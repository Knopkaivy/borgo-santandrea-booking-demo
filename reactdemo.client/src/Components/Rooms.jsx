import Room from './Room';
import NoRoomsWarning from './NoRoomsWarning';
import RoomsImagesArray from './RoomsImages';
import '../Styles/Rooms.css';

const Rooms = ({ rooms, numberGuests }) => {

    return (
        <section className="rooms">
            <h1 className="rooms__header" >SELECT A ROOM</h1>
            <div className="rooms__filters-container" >
                Filters go here
            </div>
            {
                (rooms.length > 0) ? rooms.map(room => <Room key={room.id} room={room} imgSrc={RoomsImagesArray.find(img => img.id === room.imageId)?.image} />) : <NoRoomsWarning numberGuests={numberGuests} />
            }
        </section>
    );
}

export default Rooms;