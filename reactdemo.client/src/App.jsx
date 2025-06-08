import Rooms from './Components/Rooms';
import './Styles/App.css';

function App() {


    return (
        <main className="app__main" >
            <div className="app__content--left" >
                <Rooms/>
            </div>
            <div className="app__content--right" ></div>
        </main>
    );
    
}

export default App;