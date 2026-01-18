using MediatR;

namespace CarManagement.Application.Cars.Commands.DeleteCar
{
    public record DeleteCarCommand(int Id) : IRequest;
    
}
