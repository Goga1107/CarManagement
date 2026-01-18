using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.ServiceRecords.Queries.GetServicedCarByMechanic
{
    public record GetServicedCarByMechanicQuery(int mechanicId) : IRequest<ICollection<ServiceRecord>>;
}
