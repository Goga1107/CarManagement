namespace CarManagement.Domain.Entities
{
    public class ServiceRecord
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car car { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public DateTime ServiceDate { get; set; }
        public int Mileage {  get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
    }
}
