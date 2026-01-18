using CarManagement.Domain.Interfaces;
using MediatR;

namespace CarManagement.Application.Users.Commands.verify_otp
{
    public class VerifyOtpHandler : IRequestHandler<VerifyOtpCommand, string>
    {
        private readonly IUserRepository _userRepo;
        public VerifyOtpHandler(IUserRepository repository) => _userRepo = repository;
        public async Task<string> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetByEmailAsync(request.Email);
            if (user == null || user.OtpCode != request.Code || user.OtpExpiryTime < DateTime.UtcNow)
                return string.Empty;

            user.OtpCode = null;
            user.OtpExpiryTime = null;
            await _userRepo.UpdateAsync(user);
            return _userRepo.Generate(user);
        }
    }
}
