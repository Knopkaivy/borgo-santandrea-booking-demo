namespace ReactDemo.Server.Models
{
    public class BookingDetailViewModel
    {
        public int BookingId { get; set; }
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
    }
}
