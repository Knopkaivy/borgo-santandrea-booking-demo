import Amenity from './Amenity';
import BarIcon from './Icons/BarIcon';
import BeachIcon from './Icons/BeachIcon';
import FoodIcon from './Icons/FoodIcon';
import GymIcon from './Icons/GymIcon';
import PersonIcon from './Icons/PersonIcon';
import ServicesIcon from './Icons/ServicesIcon';
import SwimIcon from './Icons/SwimIcon';
import WiFiIcon from './Icons/WiFiIcon';
import '../Styles/AmenitiesList.css';
function AmenititesList() {
    const list = [
        {
            icon: <FoodIcon />,
            description: 'The Breakfast: a unique experience with our chefs'
        },
        {
            icon: <BeachIcon />,
            description: 'Free entrance at our exclusive beach club with sunbeds, umbrella, beach toys'
        },
        {
            icon: <WiFiIcon />,
            description: 'High speed Wi-Fi'
        },
        {
            icon: <SwimIcon />,
            description: `Use of the Hotel's pool`
        },
        {
            icon: <ServicesIcon />,
            description: 'Car parking and valet service'
        },
        {
            icon: <GymIcon />,
            description: 'Fitness facilities'
        },
        {
            icon: <BarIcon />,
            description: 'Minibar - Complimentary water, soft drinks and snacks with daily stock'
        },
        {
            icon: <PersonIcon/>,
            description: 'Shuttle Service to and from Amalfi center on request'
        },
    ];

    const amenitiesList = list.map((amenity, i) => {
        return <Amenity key={i} description={amenity.description} icon={amenity.icon} />
    })

    return (
      <div className='amenities-list' >
            {amenitiesList}
        </div>
  );
}

export default AmenititesList;