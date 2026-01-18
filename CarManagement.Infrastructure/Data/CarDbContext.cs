using CarManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Infrastructure.Data
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }
        public CarDbContext(DbContextOptions<CarDbContext> options):base(options)
        {
        }
    }
}
