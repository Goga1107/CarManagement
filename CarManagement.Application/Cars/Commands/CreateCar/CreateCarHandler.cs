using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces;
using MediatR;

namespace CarManagement.Application.Cars.Commands.CreateCar
{
    public class CreateCarHandler : IRequestHandler<CreateCarCommand,int>
    {
        private readonly ICarRepository _repo;
        public CreateCarHandler(ICarRepository repository)
        {
           _repo = repository;
        }
        public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Year = request.Year,
                Engine = request.Engine,
                Description = request.Description,
                PlateNumber = request.plateNumber,
                VinNumber = request.vinNumber,
                CreatedAt = DateTime.Now,
            };
            await _repo.AddAsync(car, cancellationToken);
            return car.Id;
        }
    }
}
