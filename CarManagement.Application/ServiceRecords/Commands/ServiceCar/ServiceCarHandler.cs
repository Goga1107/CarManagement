using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces;
using MediatR;

namespace CarManagement.Application.ServiceRecords.Commands.ServiceCar
{
    public class ServiceCarHandler : IRequestHandler<ServiceCarCommand, int>
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceCarHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<int> Handle(ServiceCarCommand request, CancellationToken cancellationToken)
        {
            ServiceRecord service = new ServiceRecord
            {
                Description = request.Description,
                Cost = request.Cost,
                Mileage = request.Mileage,
                ServiceDate = DateTime.Now,
            };
             await _serviceRepository.ServiceCar(request.PlateNumber, service,cancellationToken);
            return service.Id;
        }
    }
}
