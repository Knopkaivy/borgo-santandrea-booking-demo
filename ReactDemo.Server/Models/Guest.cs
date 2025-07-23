using System.ComponentModel.DataAnnotations;

namespace ReactDemo.Server.Models
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
    }
}
