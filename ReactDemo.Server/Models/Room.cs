using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ReactDemo.Server.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public RoomType? RoomType { get; set; }
        public int RoomTypeId { get; set; }
        public int RoomNumber { get; set; }
    }
}
