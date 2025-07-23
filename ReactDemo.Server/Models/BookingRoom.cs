using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "Date")]
        public DateOnly CheckInDate { get; set; }
        [Column(TypeName = "Date")]
        public DateOnly CheckOutDate { get; set; }
        public int NumberAdults { get; set; }
        public int NumberChildren { get; set; } = 0;
    }
}
