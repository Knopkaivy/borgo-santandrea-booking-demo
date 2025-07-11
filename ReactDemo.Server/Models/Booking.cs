using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactDemo.Server.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Guest Guest { get; set; }
        public int GuestId { get; set; }
        [Column(TypeName = "Date")]
        public DateOnly CheckInDate { get; set; }
        [Column(TypeName = "Date")]
        public DateOnly CheckOutDate { get; set; }
        public int NumberAdults { get; set; }
        public int NumberChildren { get; set; } = 0;
    }
}
