using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactDemo.Server.Database;
using ReactDemo.Server.Models;
using System.Threading.Tasks;

namespace ReactDemo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context) { 
            _context = context;
        }

        //GET room/startDateString/endDateString/numberGuests
        [HttpGet("{startDateString}/{endDateString}/{numberGuests}")]
        public async Task<List<RoomViewModel>> Get(string startDateString, string endDateString, int numberGuests)
        {
            DateOnly startDate = DateOnly.Parse(startDateString);
            DateOnly endDate = DateOnly.Parse(endDateString);
            List<RoomType> roomTypesAll = await _context.RoomType.ToListAsync();
            var roomTypesAvailable = await (from rt in _context.RoomType
                                             join r in _context.Room on rt.Id equals r.RoomTypeId
                                             where (from r in _context.Room
                                                    join br in _context.BookingRoom on r.Id equals br.RoomId
                                                    join b in _context.Booking on br.BookingId equals b.Id
                                                    where br.CheckInDate <= endDate && br.CheckInDate >= startDate
                                                    select r
                                                       ).Distinct().All(brl => brl.Id != r.Id)
                                             group rt by rt.Id into g
                                             select new { id = g.Key, Count = g.Count() }
                                             ).ToArrayAsync();
            List<RoomViewModel> roomTypes = new List<RoomViewModel>();
            foreach ( var roomType in roomTypesAll)
            {
                var availableRoom = roomTypesAvailable.FirstOrDefault(rt => rt.id == roomType.Id);
                if (availableRoom != null && roomType.SleepersCapacity >= numberGuests) {
                    roomTypes.Add(new RoomViewModel
                    {
                        Id = roomType.Id,
                        Title = roomType.Name,
                        ImageId = (int)roomType.ImageId,
                        RoomDescription = roomType.Description,
                        BedsDescription = roomType.BedsDescription,
                        SleepersCapacity = roomType.SleepersCapacity,
                        RoomSize = roomType.Size,
                        Price = roomType.BasePrice,
                        RoomsAvailable = availableRoom.Count
                    });
                }
            }
            return roomTypes;
        }

    }
}
