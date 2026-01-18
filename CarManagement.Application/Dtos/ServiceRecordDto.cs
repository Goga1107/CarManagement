using CarManagement.Domain.Entities;

namespace CarManagement.Application.Dtos
{
    public class ServiceRecordDto
    {
        public int Id { get; set; }
        public DateTime ServiceDate { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public UserShortDto User { get; set; }
    }
}
