using Microsoft.AspNetCore.Mvc;
using ReactDemo.Server.Models;

namespace ReactDemo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private static readonly IEnumerable<Room> Rooms = new[]
        {
            new Room{ Id = 1, Title = "Classic Courtyard", ImageId = 1, RoomsAvailable = 1, BedsDescription = "1 Queen bed", SleepersCapacity = 2, RoomSize = "25 sq m", Price = 750.00m, RoomDescription = "1 Queen bed or 2 Twin beds – 25sqm / 269sqft. Balcony or window. Coastal view"},
            new Room{ Id = 2, Title = "Superior", ImageId = 2, RoomsAvailable = 5, BedsDescription = "1 Queen bed", SleepersCapacity = 2, RoomSize = "32 to 36 sq m", Price = 850.00m, RoomDescription = "1 Queen bed or 2 Twin beds – From 32 to 36sqm / From 345 to 388sqft. Window – Juliet balcony. Lateral Sea view/coastal view"},
            new Room{ Id = 3, Title = "Deluxe with sea view balcony", ImageId = 3, RoomsAvailable = 3, BedsDescription = "1 Queen bed", SleepersCapacity = 2, RoomSize = "35 to 40 sq m", Price = 1075.45m, RoomDescription = "1 Large Queen bed or 2 Twin beds – From 35 to 40sqm / From 377 to 431sqft. Sitting area – Desk. Balcony. Sea view"},
            new Room{ Id = 4, Title = "Junior Suite", ImageId = 4, RoomsAvailable = 5, BedsDescription = "1 King bed", SleepersCapacity = 2, RoomSize = "45 to 55 sq msquare meters", Price = 1400.00m, RoomDescription = "1 King bed or 2 Twin beds – From 45 to 55sqm / From 485 to 582sqft. Sitting area – Desk. Big window – Sea view"},
            new Room{ Id = 5, Title = "Corner Suite", ImageId = 5, RoomsAvailable = 5, BedsDescription = "1 King bed", SleepersCapacity = 3, RoomSize = "65 to 75 sq m", Price = 2100.00m, RoomDescription = "1 King bed or 2 Twin beds – From 65 to 75sqm / From 700 to 807sqft. Separate sitting area – Desk. Big window – Sea view"},
            new Room{ Id = 6, Title = "Suite Deluxe with Terrace", ImageId = 6, RoomsAvailable = 5, BedsDescription = "1 King bed", SleepersCapacity = 3, RoomSize = "107 to 120 sq m", Price = 2275.45m, RoomDescription = "1 King bed or 2 Twin beds – From 107 to 120sqm / From 1151 to 1291sqft. Separate living area – Desk. Private terrace – Sea view"},
            new Room{ Id = 7, Title = "Junior Suite sea view with Pool", ImageId = 7, RoomsAvailable = 5, BedsDescription = "1 King bed", SleepersCapacity = 2, RoomSize = "90 sq msquare meters", Price =2325.45m, RoomDescription = "1 King bed – 90sqm / 968sqft. Separate sitting area – Private terrace – Sea view. Private heated infinity plunge pool"},
            new Room{ Id = 8, Title = "Suite Deluxe with Pool", ImageId = 8, RoomsAvailable = 2, BedsDescription = "1 King bed", SleepersCapacity = 3, RoomSize = "85 to 105 sq m", Price = 2470.00m, RoomDescription = "1 King or 2 Twin beds – From 85 to 105qm. Separate living area – Desk. Private terrace – Sea view. Private heated infinity plunge pool"},
            new Room{ Id = 9, Title = "Premium Suite Pool", ImageId = 9, RoomsAvailable = 5, BedsDescription = "1 Queen bed", SleepersCapacity = 3, RoomSize = "105 sq m", Price = 2850.00m, RoomDescription = "1 King bed or 2 Twin beds – 105sqm / 1131sqft. Sitting area – Desk. Private terrace or garden – Sea view. Private heated infinity plunge pool"},
        };

        [HttpGet()]
        public Room[] Get()
        {
            Room[] rooms = Rooms.ToArray();
            return rooms;
        }
    }
}
