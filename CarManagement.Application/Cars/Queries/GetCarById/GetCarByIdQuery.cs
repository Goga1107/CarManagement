using CarManagement.Application.Dtos;
using MediatR;

namespace CarManagement.Application.Cars.Queries.GetCarById
{
    public record GetCarByIdQuery(int Id) : IRequest<CarDto>;
}
