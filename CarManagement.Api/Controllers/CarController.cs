using CarManagement.Application.Cars.Commands.CreateCar;
using CarManagement.Application.Cars.Commands.DeleteCar;
using CarManagement.Application.Cars.Queries.GetCarById;
using CarManagement.Application.Cars.Queries.GetCars;
using CarManagement.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarCommand command,CancellationToken ct)
        => Ok(await  _mediator.Send(command,ct));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken ct)
            => Ok(await _mediator.Send(new GetCarByIdQuery(id), ct));

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct) 
            => Ok(await _mediator.Send(new GetCarsQuery(),ct));

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id,CancellationToken ct)
        {
            await _mediator.Send(new DeleteCarCommand(id), ct);
            return NoContent();
        }
    }
}
