using CarManagement.Domain.Entities;

namespace CarManagement.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task AddAsync(Car car, CancellationToken token);
        Task<Car> GetByIdAsync(int id, CancellationToken token);
        Task<ICollection<Car>> GetAllAsync(CancellationToken token);
        Task DeleteAsync(Car car,CancellationToken token);
    }
}
