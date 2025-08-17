import { useState } from 'react';
import { Link, useNavigate } from "react-router";
import Navbar from "../Components/Navbar/Navbar";
import '../Styles/Pages/Register.css';

function Register() {
    const navigate = useNavigate();
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [error, setError] = useState("");

    const handleChange = (e) => {
        const { name, value } = e.target;
        if (name === "firstName") setFirstName(value);
        if (name === "lastName") setLastName(value);
        if (name === "email") setEmail(value);
        if (name === "password") setPassword(value);
        if (name === "confirmPassword") setConfirmPassword(value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        if (!email || !password || !confirmPassword) {
            setError("Please fill in all fields.");
        } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
            setError("Please enter a valid email address.");
        } else if (password !== confirmPassword) {
            setError("Passwords do not match.");
        } else {
            setError("");
            fetch("/users/register/", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    firstName: firstName,
                    lastName: lastName,
                    email: email,
                    passwordHash: password,
                }),
            })
                .then((response) => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    } else {
                        setError("Successful register.");
                    }

                })
                .catch((error) => {
                    console.error(error);
                    setError("Error registering.");
                });
        }
    };

    return (
        <>
          <Navbar/>
            <main className='register' >
                <h1 className='register__heading'>REGISTER</h1>
                <div className='register__content'>

                    {error && <p className="form__error">{error}</p>}
                    <form onSubmit={handleSubmit}>
                        <div className='form__input-field'>
                            <label htmlFor="firstName" className='form__label' >
                                <span>First Name</span>
                                <input type="text" id="firstName" name="firstName" value={firstName} onChange={handleChange} />
                            </label>
                            </div><div>
                        </div>
                        <div className='form__input-field'>
                            <label htmlFor="lastName" className='form__label' >
                                <span>Last Name</span>
                                <input type="text" id="lastName" name="lastName" value={lastName} onChange={handleChange} />
                            </label>
                            </div><div>
                        </div>
                        <div className='form__input-field'>
                            <label htmlFor="email" className='form__label' >
                                <span>Email<span className='required' >*</span></span>
                                <input type="email" id="email" name="email" value={email} onChange={handleChange} />
                            </label>
                            </div><div>
                        </div>
                        <div className='form__input-field'>
                            <label htmlFor="password" className='form__label'>
                                <span>Password<span className='required' >*</span></span>
                                <input type="password" id="password" name="password" value={password} onChange={handleChange} />
                            </label>
                            </div><div>
                        </div>
                        <div className='form__input-field'>
                            <label htmlFor="confirmPassword" className='form__label'>
                                <span>Confirm Password<span className='required' >*</span></span>
                                <input type="password" id="confirmPassword" name="confirmPassword" value={confirmPassword} onChange={handleChange} />
                            </label>
                            </div><div>
                        </div>
                        <div className='button__container'>
                            <button type="submit" className='button button--blue'>REGISTER</button>
                            <Link to="/login" className='button button-link button--blue-light' >GO TO SIGN IN PAGE</Link>
                        </div>
                    </form>

                    
                </div>
            </main>
            
      </>
  );
}

export default Register;