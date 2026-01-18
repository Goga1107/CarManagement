using MediatR;

namespace CarManagement.Application.Users.Commands.verify_otp
{
    public class VerifyOtpCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
