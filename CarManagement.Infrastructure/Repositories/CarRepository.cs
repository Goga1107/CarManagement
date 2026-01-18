using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces;
using CarManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _db;
        public CarRepository(CarDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task AddAsync(Car car, CancellationToken token)
        {
           _db.Cars.Add(car);
           await _db.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(Car car, CancellationToken token)
        {
            _db.Cars.Remove(car);
            await _db.SaveChangesAsync(token);
        }

        public async Task<ICollection<Car>> GetAllAsync(CancellationToken token)
        {
            var cars = await _db.Cars.ToListAsync(token);
            return cars;
        }

        public async Task<Car> GetByIdAsync(int id, CancellationToken token)
        {
            var car = await _db.Cars.FirstOrDefaultAsync(c=> c.Id == id,token);
        
            return car;
        }
    }
}
