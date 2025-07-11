import '../Styles/NoRoomsWarning.css';
function NoRoomsWarning({ numberGuests }) {
    return (
      <div className='no-rooms-warning' >
            <p className='no-rooms-warning__description'>No rooms are available to accommodate {numberGuests} guests.</p>
            <p className='no-rooms-warning__action'>Try reducing the number of guests and/or booking multiple rooms.</p>
      </div>
  );
}

export default NoRoomsWarning;