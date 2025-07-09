using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ReactDemo.Server.Models
{
    public class RoomType
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        [Precision(18, 2)]
        public required decimal BasePrice { get; set; }
        public required string Size { get; set; }
        public required int SleepersCapacity { get; set; }
        public required string Description { get; set; }
        public required string BedsDescription { get; set; }
        public int? ImageId { get; set; }
    }
}
