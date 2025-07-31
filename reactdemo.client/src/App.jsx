import { BrowserRouter, Routes, Route } from 'react-router';
import Home from './Components/Pages/Home';
import Login from './Components/Pages/Login';
import Register from './Components/Pages/Register';
import './Styles/App.css';

function App() {

    return (
        <BrowserRouter>
            <Routes>
                <Route index element={<Home/>} />
                <Route path='/login' element={<Login/>} />
                <Route path='/register' element={<Register/>} />
            </Routes>
        </BrowserRouter>
    )
    
}

export default App;