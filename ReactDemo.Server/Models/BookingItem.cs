using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactDemo.Server.Models
{
    public class BookingItem
    {
        public int RoomTypeId { get; set; }
        public string CheckInDateString { get; set; }
        public string CheckOutDateString { get; set; }
        public int NumberAdults { get; set; }
        public int NumberChildren { get; set; } = 0;
    }
}
