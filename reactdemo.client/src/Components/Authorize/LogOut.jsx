import { useNavigate } from "react-router";
import '../../Styles/Components/Authorize/LogOut.css';
function LogOut() {
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        fetch("/logout", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: ""

        })
            .then((data) => {
                if (data.ok) {

                    navigate("/login");
                }
                else { }

            })
            .catch((error) => {
                console.error(error);
            })

    };
    return (
      <div className='logout' >
            <a href="#" onClick={handleSubmit} >SIGN OUT</a>
      </div>
  );
}

export default LogOut;