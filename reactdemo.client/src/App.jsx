import AmenititesList from './Components/AmenititesList';
import BookingSection from './Components/Booking/BookingSection';
import Cart from './Components/Cart';
import Rooms from './Components/Rooms';
import './Styles/App.css';

function App() {


    return (
        <main className="app__main" >
            <div className="app__content--left" >
                <BookingSection/>
                <Rooms/>
            </div>
            <div className="app__content--right" >
                <Cart/>
                <AmenititesList/>
            </div>
        </main>
    );
    
}

export default App;