using CarManagement.Application.Users.Commands.login;
using CarManagement.Application.Users.Commands.Register;
using CarManagement.Application.Users.Commands.verify_otp;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var userId = _mediator.Send(command);
            return Ok(new {Id = userId});
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var token = _mediator.Send(command);
            return Ok(new {Token = token});
        }
        [HttpPost("Verify-Otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpCommand command)
        {
            var token = await _mediator.Send(command);

            if (string.IsNullOrEmpty(token))
                return BadRequest("კოდი არასწორია ან ვადაგასულია");

            return Ok(new { Token = token });
        }
    }
}
