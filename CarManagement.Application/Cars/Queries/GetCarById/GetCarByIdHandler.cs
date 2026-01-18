using CarManagement.Application.Dtos;
using CarManagement.Domain.Interfaces;
using MediatR;

namespace CarManagement.Application.Cars.Queries.GetCarById
{
    public class GetCarByIdHandler : IRequestHandler<GetCarByIdQuery,CarDto>
    {
        private readonly ICarRepository _repo;
        public GetCarByIdHandler(ICarRepository repository)
        {
            _repo = repository;
        }

        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _repo.GetByIdAsync(request.Id, cancellationToken);
            if (car == null) return null;
                return new CarDto
                {
                    Id = car.Id,
                    Manufacturer = car.Manufacturer,
                    Model = car.Model,
                    Year = car.Year,
                    Description = car.Description,
                    Engine = car.Engine,
                };
        }
    }
}
