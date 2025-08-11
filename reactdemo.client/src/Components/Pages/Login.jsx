import { useState } from 'react';
import { Link, useNavigate } from "react-router";
import Navbar from '../Navbar/Navbar';
import '../../Styles/Pages/Login.css';
function Login() {
    // state variables for email and passwords
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [rememberme, setRememberme] = useState(false);
    // state variable for error messages
    const [error, setError] = useState("");
    const navigate = useNavigate();

    // handle change events for input fields
    const handleChange = (e) => {
        const { name, value } = e.target;
        if (name === "email") setEmail(value);
        if (name === "password") setPassword(value);
        if (name === "rememberme") setRememberme(e.target.checked);
    };

    const handleRegisterClick = () => {
        navigate("/register");
    }

    // handle submit event for the form
    const handleSubmit = (e) => {
        e.preventDefault();
        // validate email and passwords
        if (!email || !password) {
            setError("Please fill in all fields.");
        } else {
            // clear error message
            setError("");
            // post data to the /register api

            var loginurl = "";
            if (rememberme == true)
                loginurl = "/login?useCookies=true";
            else
                loginurl = "/login?useSessionCookies=true";

            fetch(loginurl, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    email: email,
                    password: password,
                }),
            })

                .then((data) => {
                    // handle success or error from the server
                    console.log(data);
                    if (data.ok) {
                        setError("Successful Login.");
                        window.location.href = '/';
                    }
                    else
                        setError("Error Logging In.");

                })
                .catch((error) => {
                    // handle network error
                    console.error(error);
                    setError("Error Logging in.");
                });
        }
    };
    return (
      <>
          <Navbar/>
            <main className='login'>
                <h1 className='login__heading' >Login</h1>
                <div className='login__content' >
                    {error && <p className="form__error">{error}</p>}
                    <form onSubmit={handleSubmit}>
                        <div className='form__input-field'>
                            <label className="forminput" htmlFor="email" className='form__label'>
                                <span>Email<span className='required' >*</span></span>
                                <input type="email" id="email" name="email" value={email} onChange={handleChange} />
                            </label>
                        </div>
                        <div className='form__input-field'>
                            <label htmlFor="password" className='form__label'>
                                <span>Password<span className='required' >*</span></span>
                                <input type="password" id="password" name="password" value={password} onChange={handleChange} />
                            </label>
                        </div>
                        <div>
                            <input type="checkbox" id="rememberme" name="rememberme" checked={rememberme} onChange={handleChange} /><span>Remember Me</span>
                        </div>
                        <div className='button__container' >
                            <button type="submit" className='button--blue' >SIGN IN</button>
                            <Link to="/register" className='button button--blue-light' >GO TO REGISTER PAGE</Link>
                        </div>
                    </form>
                    
                </div>
            </main>
      </>
  );
}

export default Login;