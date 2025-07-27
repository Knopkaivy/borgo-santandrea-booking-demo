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

        //POST: room/book
        [HttpPost("book")]
        public async Task<IActionResult> Post([FromBody] BookingRequest bookingRequest)
        {
            int bookingId;
            try
            {

                int guestId;
                Guest guest = await _context.Guest.Where(g => g.Email == bookingRequest.Email).FirstOrDefaultAsync();
                if (guest != null) {
                    guestId = guest.Id;
                } else
                {
                    Guest newGuest = new Guest
                    {
                        Email = bookingRequest.Email,
                        FirstName = bookingRequest.FirstName,
                        LastName = bookingRequest.LastName,
                    };

                    _context.Add(newGuest);
                    await _context.SaveChangesAsync();
                    guestId = newGuest.Id;
                }

                    Booking booking = new Booking
                    {
                        GuestId = guestId,
                    };
                    _context.Add(booking);
                    await _context.SaveChangesAsync();
                    bookingId = booking.Id;
                List<BookingRoom> roomList = new List<BookingRoom>();
                List<int> roomIdList = new List<int>();

                foreach( BookingItem bookingItem in bookingRequest.BookingItems)
                {
                    DateOnly CheckInDate = DateOnly.Parse(bookingItem.CheckInDateString);
                    DateOnly CheckOutDate = DateOnly.Parse(bookingItem.CheckOutDateString);
                    List<int> bookedRooms = await (from r in _context.Room
                                 join br in _context.BookingRoom on r.Id equals br.RoomId
                                 join b in _context.Booking on br.BookingId equals b.Id
                                 where  br.CheckInDate <= CheckOutDate && br.CheckInDate >= CheckInDate
                                 select r.Id).ToListAsync();
                    List<Room> availableRooms = await _context.Room.Where(r => r.RoomTypeId == bookingItem.RoomTypeId).Where(r => !bookedRooms.Any(br => br == r.Id)).ToListAsync();
                    Room? room = await _context.Room.Where(r => r.RoomTypeId == bookingItem.RoomTypeId).Where(r => !bookedRooms.Any(br => br == r.Id)).Where(r => !roomIdList.Any(ri => ri ==r.Id)).FirstOrDefaultAsync();

                    BookingRoom newBookingRoom = new BookingRoom
                    {
                        BookingId = bookingId,
                        RoomId = room.Id,
                        CheckInDate = CheckInDate,
                        CheckOutDate = CheckOutDate,
                        NumberAdults = bookingItem.NumberAdults,
                        NumberChildren = bookingItem.NumberChildren,
                    };
                    roomList.Add(newBookingRoom);
                    roomIdList.Add(room.Id);
                };
                    _context.AddRange(roomList);
                    await _context.SaveChangesAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
                return BadRequest();
            }

            return Ok(bookingId);
        }
    }
}
