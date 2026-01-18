using CarManagement.Domain.Entities;



namespace CarManagement.Domain.Interfaces
{
    public interface IServiceRepository
    {
        Task<ServiceRecord> ServiceCar(string plateNumber,ServiceRecord service, CancellationToken token);
        Task<ICollection<ServiceRecord>> GetServicedCarByPlate(string plateNumber);
        Task<ICollection<ServiceRecord>> GetServicedCarsByMechanicId(int mechanicId);
        
    }
}
