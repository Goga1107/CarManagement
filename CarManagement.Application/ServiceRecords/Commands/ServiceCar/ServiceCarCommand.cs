using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.ServiceRecords.Commands.ServiceCar
{
    public record ServiceCarCommand(
           string PlateNumber,
           int Mileage,
           string Description,
           double Cost
        ) : IRequest<int>;
}
