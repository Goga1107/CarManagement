using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces;
using MediatR;
using CarManagement.Application.Dtos;

namespace CarManagement.Application.ServiceRecords.Queries.GetServicedCarByPlate
{
    public class GetServicedCarByPlateHandler : IRequestHandler<GetServicedCarByPlateQuery, ICollection<ServiceRecord>>
    {
        private readonly IServiceRepository _serviceRepository;
        public GetServicedCarByPlateHandler(IServiceRepository repository)
        {
            _serviceRepository = repository;
        }
        public async Task<ICollection<ServiceRecord>> Handle(GetServicedCarByPlateQuery request, CancellationToken cancellationToken)
        {
            var record = await _serviceRepository.GetServicedCarByPlate(request.PlateNumber);
            if (record == null)
            {
                throw new KeyNotFoundException($"service history of this car not found {request.PlateNumber}");
            }
            return record;
        }
    }
}
