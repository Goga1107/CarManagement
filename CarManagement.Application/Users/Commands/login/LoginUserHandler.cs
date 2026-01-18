using CarManagement.Domain.Interfaces;
using MediatR;

namespace CarManagement.Application.Users.Commands.login
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly IUserRepository _userRepo;
        private readonly IEmailService _emailService;
        public LoginUserHandler(IUserRepository repository,IEmailService email)
        {
            _userRepo = repository;
            _emailService = email;
        }
        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetByEmailAsync(request.email);
            if (user == null) return false;
            if (!_userRepo.Verify(request.password, user.PasswordHash)) return false;
            var otpCode = new Random().Next(100000, 999999).ToString();
            user.OtpCode = otpCode;
            user.OtpExpiryTime = DateTime.UtcNow.AddMinutes(5);
            await _userRepo.UpdateAsync(user);
            await _emailService.SendEmailAsync(user.Email, "ავტორიზაციის კოდი", $"თქვენი კოდია: {otpCode}");
            return true;
        }
    }
}
