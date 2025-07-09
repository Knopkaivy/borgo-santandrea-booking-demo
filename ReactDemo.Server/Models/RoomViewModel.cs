namespace ReactDemo.Server.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ImageId {  get; set; }
        public string RoomDescription { get; set; }
        public string BedsDescription { get; set; }
        public int SleepersCapacity { get; set; }
        public string RoomSize { get; set; }
        public decimal Price { get; set; }
        public int RoomsAvailable { get; set; } = 3;
    }
}
