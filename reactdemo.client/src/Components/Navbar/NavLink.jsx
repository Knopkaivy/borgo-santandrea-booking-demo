import { Link } from "react-router";
import '../../Styles/Navbar/NavLink.css';
function NavLink({hrefVal, text}) {
  return (
      <li className='navlink' >
          <Link to={hrefVal} >{text}</Link>
      </li>
  );
}

export default NavLink;