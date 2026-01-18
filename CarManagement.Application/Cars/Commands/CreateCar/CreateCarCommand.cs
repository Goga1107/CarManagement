using MediatR;

namespace CarManagement.Application.Cars.Commands.CreateCar
{
    public record CreateCarCommand(
    string Manufacturer ,
    string Model ,
    int Year ,
    double Engine ,
    string Description,
    string plateNumber,
    string vinNumber
    ) : IRequest<int>;
}
