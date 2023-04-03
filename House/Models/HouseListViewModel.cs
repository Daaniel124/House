namespace House.Models
{
    public class HouseListViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Square { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
