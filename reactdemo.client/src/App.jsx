import { BrowserRouter, Routes, Route } from 'react-router';
import AllBookings from './Pages/AllBookings';
import BookingDetail from './Pages/BookingDetail';
import BookingEdit from './Pages/BookingEdit';
import Home from './Pages/Home';
import FindBooking from './Components/MyBookings/FindBooking';
import Login from './Pages/Login';
import Register from './Pages/Register';
import './Styles/App.css';

function App() {

    return (
        <BrowserRouter>
            <Routes>
                <Route index element={<Home/>} />
                <Route path='/bookings' element={<AllBookings/>} />
                <Route path='/booking/detail/:id' element={<BookingDetail/>} />
                <Route path='/booking/edit/:id' element={<BookingEdit/>} />
                <Route path='/find' element={<FindBooking/>} />
                <Route path='/login' element={<Login/>} />
                <Route path='/register' element={<Register/>} />
            </Routes>
        </BrowserRouter>
    )
    
}

export default App;