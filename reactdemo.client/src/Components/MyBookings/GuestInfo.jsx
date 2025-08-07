import '../../Styles/MyBookings/GuestInfo.css';
function GuestInfo({first, last, email }) {
  return (
      <div className='guest-info' >
          <div><span className='bold' >First Name: </span>{first} </div>
          <div><span className='bold' >Last Name: </span>{last}</div>
          <div><span className='bold' >Email: </span>{email}</div>
      </div>
  );
}

export default GuestInfo;