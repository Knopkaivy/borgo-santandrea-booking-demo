import '../../Styles/Navbar/NavLink.css';
function NavLink({text}) {
  return (
      <li >
          <a href='/'  className='navlink'>
              {text}
          </a>
      </li>
  );
}

export default NavLink;