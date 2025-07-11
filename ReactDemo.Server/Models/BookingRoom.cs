using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ReactDemo.Server.Models
{
    public class BookingRoom
    {
        [Key]
        public int Id { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Booking Booking { get; set; }
        public int BookingId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Room Room { get; set; }
        public int RoomId {  get; set; }
    }
}
