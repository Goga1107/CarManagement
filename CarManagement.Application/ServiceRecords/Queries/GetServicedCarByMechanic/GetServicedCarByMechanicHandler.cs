using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces;
using MediatR;

namespace CarManagement.Application.ServiceRecords.Queries.GetServicedCarByMechanic
{
    public class GetServicedCarByMechanicHandler : IRequestHandler<GetServicedCarByMechanicQuery, ICollection<ServiceRecord>>
    {
        private readonly IServiceRepository _repo;
        public GetServicedCarByMechanicHandler(IServiceRepository repository)
        {
            _repo = repository;
        }
        public async Task<ICollection<ServiceRecord>> Handle(GetServicedCarByMechanicQuery request, CancellationToken cancellationToken)
        {
            var serv = await _repo.GetServicedCarsByMechanicId(request.mechanicId);
            if (serv == null) throw new KeyNotFoundException("mechanic not found");
            return serv;
        }
    }
}
