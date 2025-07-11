import CardIcon from './Icons/CardIcon';
import CoffeeIcon from './Icons/CoffeeIcon';
import ImagesIcon from './Icons/ImagesIcon';
import '../Styles/Room.css';

const Room = ({ room, imgSrc }) => {

    const detailsList = room.roomDescription.split(".").map((descriptionItem, i) => <li className="room__details-list-item" key={i} >{descriptionItem}</li>)

    return (
        <div className="room" >
            <div className="room__image-container" >
                <img className="room__image" src={imgSrc} />
                <div className="room__image-icon-container">
                    <ImagesIcon/>
                </div>
            </div>
            <div className="room__content-container">
                <h2 className="room__header" >{room.title}</h2>
                <div className="room__specifications" >
                    <span className={`room__specifications-item room__specifications-item--availablity ${room.roomsAvailable > 2 ? "hide" : ""}`}>Only {room.roomsAvailable} room{room.roomsAvailable > 1 ? "s" : ""} left</span>
                    <span className="room__specifications-item room__specifications-item--with-separator">{room.bedsDescription}</span>
                    <span className="room__specifications-item room__specifications-item--with-separator">Sleeps {room.sleepersCapacity}</span>
                    <span className="room__specifications-item">{room.roomSize}</span>
                </div>
                <div className="room__info" ></div>
                <div className="room__details" >
                    <ul className="room__details-list" >{detailsList}</ul>
                    <a href="/" className="room__link" >Room Details</a>
                </div>
                <div className="room__additional-info" >
                    <div className="room__additional--left" >
                        <a href="/" className="room__link" >Best available flexible rate</a>
                        <p className="room__additional-description" >
                            <CardIcon />
                            <span className="room__additional-description-text" >
                                Deposit Required
                            </span>
                            </p>
                        <p className="room__additional-description">
                            <CoffeeIcon />
                            <span className="room__additional-description-text">
                                Breakfast Included
                            </span>
                        </p>
                        <p className="room__additional-rate-description" >Full breakfast, Wi-Fi, shuttle service, private beach, private parking, swimming pool</p>
                    </div>
                    <div className="room__additional--right">
                        <p className="room__price" ><span>$</span>{Number.parseFloat(room.price).toFixed(2)}</p>
                        <p className="room__price-description" >Per Night</p>
                        <p className="room__price-description room__price-description--fees">Excluding taxes and fees</p>
                        <button className="room__button" >BOOK NOW</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Room;