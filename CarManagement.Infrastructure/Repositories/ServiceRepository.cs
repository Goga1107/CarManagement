using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces;
using CarManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarManagement.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly CarDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public ServiceRepository(CarDbContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public Task<ServiceRecord> GetAllServicesOfCarByPlate(string plateNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ServiceRecord>> GetServicedCarByPlate(string plateNumber)
        {
            var car = await _context.ServiceRecords.Include(u=> u.user).Include(c=> c.car).Where(c => c.car.PlateNumber == plateNumber).ToListAsync();
            return car;
        }

        public async Task<ICollection<ServiceRecord>> GetServicedCarsByMechanicId(int mechanicId)
        {
            var service = await _context.ServiceRecords.Include(u=> u.user).Include(c=> c.car).Where(m=> m.UserId == mechanicId).ToListAsync();
            return service;
        }

        public async Task<ServiceRecord> ServiceCar(string PlateNumber,ServiceRecord service,CancellationToken token)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c=> c.PlateNumber == PlateNumber);
            if (car == null) { return null; }
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                          ?? _httpContextAccessor.HttpContext?.User.FindFirst("sub")?.Value;
            if (string.IsNullOrEmpty(userIdClaim)) throw new Exception("mechanic is not authorized");
            service.CarId = car.Id;
            service.UserId = int.Parse(userIdClaim);
            service.ServiceDate = DateTime.UtcNow;
            _context.ServiceRecords.Add(service);
            await _context.SaveChangesAsync(token);
            return service;
        }
    }
}
