using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactDemo.Server.Database;
using ReactDemo.Server.Models;

namespace ReactDemo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;

        public BookingController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //GET booking/
        [Authorize(Roles = "Administrator,User,FrontDesk")]
        [HttpGet()]
        public async Task<List<BookingViewModel>> Get()
        {
            List<BookingViewModel> bookingViewList = new List<BookingViewModel>();
            AppUser currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if(currentUser != null)
            {
                List<Booking> bookings = new List<Booking>();
                var roles = await _userManager.GetRolesAsync(currentUser);
                if (roles.Contains("Administrator") || roles.Contains("FrontDesk"))
                {
                    bookings = await _context.Booking.ToListAsync();
                } else if (roles.Contains("User"))
                {
                    bookings = await ( from b in _context.Booking
                                       join g in _context.Guest on b.GuestId equals g.Id
                                       where g.Email == currentUser.Email
                                       select b
                        ).ToListAsync();
                }

                    foreach (Booking booking in bookings)
                    {
                        var guest = await _context.Guest.Where(g => g.Id == booking.GuestId).FirstOrDefaultAsync();
                        if (guest != null)
                        {
                            bookingViewList.Add(new BookingViewModel
                            {
                                BookingId = booking.Id,
                                GuestId = guest.Id,
                                FirstName = guest.FirstName,
                                LastName = guest.LastName,
                                Email = guest.Email,
                            });
                        }
                    }
            }


            return bookingViewList;
        }

        //GET booking/5/test@test.com
        [HttpGet("{bookingId}/{email}")]
        public async Task<List<BookingViewModel>> Get(int bookingId, string email)
        {
            List<BookingViewModel> bookingViewList = new List<BookingViewModel>();

            List<Booking> bookings = await _context.Booking.Where(b => b.Id ==bookingId).ToListAsync();

            foreach (Booking booking in bookings)
            {
                var guest = await _context.Guest.Where(g => g.Id == booking.GuestId).FirstOrDefaultAsync();
                if (guest != null)
                {
                    bookingViewList.Add(new BookingViewModel
                    {
                        BookingId = booking.Id,
                        GuestId = guest.Id,
                        FirstName = guest.FirstName,
                        LastName = guest.LastName,
                        Email = guest.Email,
                    });
                }
            }

            return bookingViewList;
        }

        //GET booking/detail/get/5
        [HttpGet("detail/get/{bookingId}/")]
        public async Task<BookingViewModel> GetBookingDetail(int bookingId)
        {
            BookingViewModel bookingViewModel = new BookingViewModel();

            try
            {
                var booking = await _context.Booking.Where(b => b.Id == bookingId).FirstOrDefaultAsync();
                var guest = await _context.Guest.Where(g => g.Id == booking.GuestId).FirstOrDefaultAsync();
                List<BookingRoom> roomList = await _context.BookingRoom.Where(br => br.BookingId == bookingId).ToListAsync();
                List<BookingRoomViewModel> roomViewList = new List<BookingRoomViewModel>();

                foreach (var room in roomList) {
                    var roomType = await (from r in _context.Room
                                            join rt in _context.RoomType on r.RoomTypeId equals rt.Id
                                            where r.Id == room.RoomId
                                            select rt
                                            ).FirstOrDefaultAsync();
                    roomViewList.Add(new BookingRoomViewModel
                    {
                        RoomId = room.RoomId,
                        CheckInDate = room.CheckInDate,
                        CheckOutDate = room.CheckOutDate,
                        NumberAdults = room.NumberAdults,
                        NumberChildren = room.NumberChildren,
                        Price = roomType.BasePrice,
                        Name = roomType.Name,
                    });
                }

                bookingViewModel.BookingId = bookingId;
                bookingViewModel.GuestId = guest.Id;
                bookingViewModel.FirstName = guest.FirstName;
                bookingViewModel.LastName = guest.LastName;
                bookingViewModel.Email = guest.Email;
                bookingViewModel.Rooms = roomViewList;
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
            }

            return bookingViewModel;
        }

        //POST: booking/book
        [HttpPost("book")]
        public async Task<IActionResult> Post([FromBody] BookingRequest bookingRequest)
        {
            int bookingId;
            try
            {

                int guestId;
                Guest guest = await _context.Guest.Where(g => g.Email == bookingRequest.Email).FirstOrDefaultAsync();
                if (guest != null)
                {
                    guestId = guest.Id;
                }
                else
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

                foreach (BookingItem bookingItem in bookingRequest.BookingItems)
                {
                    DateOnly CheckInDate = DateOnly.Parse(bookingItem.CheckInDateString);
                    DateOnly CheckOutDate = DateOnly.Parse(bookingItem.CheckOutDateString);
                    List<int> bookedRooms = await (from r in _context.Room
                                                   join br in _context.BookingRoom on r.Id equals br.RoomId
                                                   join b in _context.Booking on br.BookingId equals b.Id
                                                   where br.CheckInDate <= CheckOutDate && br.CheckInDate >= CheckInDate
                                                   select r.Id).ToListAsync();
                    List<Room> availableRooms = await _context.Room.Where(r => r.RoomTypeId == bookingItem.RoomTypeId).Where(r => !bookedRooms.Any(br => br == r.Id)).ToListAsync();
                    Room? room = await _context.Room.Where(r => r.RoomTypeId == bookingItem.RoomTypeId).Where(r => !bookedRooms.Any(br => br == r.Id)).Where(r => !roomIdList.Any(ri => ri == r.Id)).FirstOrDefaultAsync();

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
                }
                ;
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

        // PUT: booking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, BookingViewModel booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest("ID in URL doesn't match ID in request body");
            }

            try
            {
                List<BookingRoom> bookingRooms = await _context.BookingRoom.Where(br => br.BookingId == booking.BookingId).ToListAsync();
                List<BookingRoom> bookingRoomsUpdated = new List<BookingRoom>();
                foreach (BookingRoomViewModel room in booking.Rooms) {
                    bookingRoomsUpdated.Add(
                        new BookingRoom
                        {
                            BookingId = booking.BookingId,
                            RoomId = room.RoomId,
                            CheckInDate = room.CheckInDate,
                            CheckOutDate = room.CheckOutDate,
                            NumberAdults = room.NumberAdults,
                            NumberChildren = room.NumberChildren,
                        });
                };

                _context.BookingRoom.RemoveRange(bookingRooms);
                _context.BookingRoom.AddRange(bookingRoomsUpdated);
                await _context.SaveChangesAsync();
                return Ok(booking);
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
        }

            // DELETE: booking/5
            [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            try
            {
                var booking = await _context.Booking.FirstOrDefaultAsync(b => b.Id == id);
                if (booking != null)
                {
                    _context.Booking.Remove(booking);
                    await _context.SaveChangesAsync();
                }
                
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

            return NoContent();
        }
    }
}
