namespace CarManagement.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Engine { get; set; }
        public string Description { get; set; }
        public string VinNumber { get; set; }
        public string PlateNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
