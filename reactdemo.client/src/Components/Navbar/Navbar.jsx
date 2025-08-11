import LogoImage from '../../assets/Images/BorgoSALogo.webp';
import LogOut from '../Authorize/LogOut';
import NavLink from './NavLink';

import '../../Styles/Navbar/Navbar.css';
import AuthorizeView from '../Authorize/AuthorizeView';
import UnauthorizeView from '../Authorize/UnauthorizeView';
function Navbar() {
  return (
      <div className='navbar' >
          <nav className='navbar__content' >
              <div className='navbar__logo-container' >
                  <img src={LogoImage} />
              </div>
              <ul className='navbar__link-list'>
                  <NavLink hrefVal='/' text='Add a room' />
                  <AuthorizeView>
                    <NavLink hrefVal='/bookings' text='All bookings' />
                    <LogOut />
                  </AuthorizeView>
                  <UnauthorizeView>
                    <NavLink hrefVal='/find' text='Find booking' />
                    <NavLink hrefVal='/login' text='Sign in' />
                  </UnauthorizeView>
              </ul>
          </nav>
      </div>
  );
}

export default Navbar;