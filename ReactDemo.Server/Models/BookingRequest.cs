namespace ReactDemo.Server.Models
{
    public class BookingRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BookingItem> BookingItems { get; set; }
    }
}
