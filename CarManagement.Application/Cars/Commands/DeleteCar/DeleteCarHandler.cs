using CarManagement.Domain.Interfaces;
using MediatR;

namespace CarManagement.Application.Cars.Commands.DeleteCar
{
    public class DeleteCarHandler : IRequestHandler<DeleteCarCommand>
    {
        private readonly ICarRepository _repo;
        public DeleteCarHandler(ICarRepository repository)
        {
            _repo = repository;
        }
        public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _repo.GetByIdAsync(request.Id, cancellationToken);
            if (car != null)
                await _repo.DeleteAsync(car, cancellationToken);
        }
    }
}
