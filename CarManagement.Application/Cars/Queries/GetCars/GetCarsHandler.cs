using CarManagement.Application.Dtos;
using CarManagement.Domain.Interfaces;
using MediatR;

namespace CarManagement.Application.Cars.Queries.GetCars
{
    public class GetCarsHandler : IRequestHandler<GetCarsQuery,ICollection<CarDto>>
    {
        private readonly ICarRepository _repo;
        public GetCarsHandler(ICarRepository repository)
        {
            _repo = repository;
        }

        public async Task<ICollection<CarDto>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _repo.GetAllAsync(cancellationToken);
            return cars.Select(car => new CarDto
            {
                Id = car.Id,
                Manufacturer = car.Manufacturer,
                Model = car.Model,
                Year = car.Year,
                Description = car.Description,
                Engine = car.Engine,
            }).ToList();
        }
    }
}
