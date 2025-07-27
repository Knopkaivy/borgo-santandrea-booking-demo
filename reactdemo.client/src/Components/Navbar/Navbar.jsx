import LogoImage from '../../assets/Images/BorgoSALogo.webp';
import '../../Styles/Navbar/Navbar.css';
import NavLink from './NavLink';
function Navbar() {
  return (
      <div className='navbar' >
          <nav className='navbar__content' >
              <div className='navbar__logo-container' >
                  <img src={LogoImage} />
              </div>
              <ul className='navbar__link-list'>
                <NavLink text='Add a room' />
                <NavLink text='My bookings' />
                <NavLink text='Sign in' />
              </ul>
          </nav>
      </div>
  );
}

export default Navbar;