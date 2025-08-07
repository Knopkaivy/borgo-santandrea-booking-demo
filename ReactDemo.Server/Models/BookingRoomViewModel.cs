using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactDemo.Server.Models
{
    public class BookingRoomViewModel
    {
        public int RoomId {  get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public int NumberAdults { get; set; }
        public int NumberChildren { get; set; }
    }
}
