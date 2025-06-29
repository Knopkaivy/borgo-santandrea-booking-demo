import AmenititesList from './Components/AmenititesList';
import BookingSection from './Components/Booking/BookingSection';
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
                <AmenititesList/>
            </div>
        </main>
    );
    
}

export default App;