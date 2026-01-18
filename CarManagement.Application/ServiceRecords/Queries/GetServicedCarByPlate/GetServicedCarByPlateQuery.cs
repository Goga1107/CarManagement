using CarManagement.Domain.Entities;
using MediatR;
using CarManagement.Application.Dtos;

namespace CarManagement.Application.ServiceRecords.Queries.GetServicedCarByPlate
{
    public record GetServicedCarByPlateQuery(string PlateNumber) : IRequest<ICollection<ServiceRecord>>;
}
