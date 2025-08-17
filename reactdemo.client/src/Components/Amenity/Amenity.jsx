import '../../Styles/Components/Amenity/Amenity.css';
function Amenity({description, icon}) {
  return (
      <div className='amenity' >
          <div className='amenity__icon'>{icon}</div>
          <div className='amenity__description' >{description}</div>
      </div>
  );
}

export default Amenity;