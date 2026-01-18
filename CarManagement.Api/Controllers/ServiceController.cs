using CarManagement.Application.ServiceRecords.Commands.ServiceCar;
using CarManagement.Application.ServiceRecords.Queries.GetServicedCarByPlate;
using CarManagement.Application.ServiceRecords.Queries.GetServicedCarByMechanic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "Mechanic")]
        [HttpPost("ServiceCar")]
        public async Task<IActionResult> ServiceCar(ServiceCarCommand command, CancellationToken token)
            => Ok(await _mediator.Send(command, token));

        [Authorize(Roles = "Mechanic")]
        [HttpGet("byPlate/{plateNumber}")]
        public async Task<IActionResult> GetServicedCarByPlate(string plateNumber, CancellationToken token)
        {
            var query = new GetServicedCarByPlateQuery(plateNumber);
            var result = await _mediator.Send(query,token);
            return Ok(result);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("ByMechanicId/{mechanicId}")]
        public async Task<IActionResult> GetServicedCarByMechanicForAdmin(int mechanicId, CancellationToken token)
        {
            var query = new GetServicedCarByMechanicQuery(mechanicId);
            var res = await _mediator.Send(query, token);
            return Ok(res);
        }
    }

}
