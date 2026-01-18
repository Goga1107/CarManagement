using CarManagement.Application.Dtos;
using MediatR;

namespace CarManagement.Application.Cars.Queries.GetCars
{
    public record GetCarsQuery : IRequest<ICollection<CarDto>>;
}
