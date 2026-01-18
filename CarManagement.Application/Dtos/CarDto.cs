namespace CarManagement.Application.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Engine { get; set; }
        public string Description { get; set; }
    }
}
