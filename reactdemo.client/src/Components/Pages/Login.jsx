import { Link } from "react-router";
import Navbar from '../Navbar/Navbar';
import '../../Styles/Pages/Login.css';
function Login() {
    return (
      <>
          <Navbar/>
            <div className='login' >Login Page</div>
            <Link to="/register">Register</Link>
      </>
  );
}

export default Login;