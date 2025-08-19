import LogoImage from '../../assets/Images/BorgoSALogo.webp';
import LogOut from '../Authorize/LogOut';
import NavLink from './NavLink';

import AuthorizeView from '../Authorize/AuthorizeView';
import UnauthorizeView from '../Authorize/UnauthorizeView';
import '../../Styles/Components/Navbar/Navbar.css';

function Navbar() {
  return (
      <div className='navbar' >
          <nav className='navbar__content' >
              <a href="https://borgo-santandrea-home-demo.web.app/" target="_blank" rel="noopener noreferrer"  className='navbar__logo-container' >
                  <img src={LogoImage} />
              </a>
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