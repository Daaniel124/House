namespace House.Models
{
    public class HouseEditViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Square { get; set; }
        public int NumberOfRooms { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
