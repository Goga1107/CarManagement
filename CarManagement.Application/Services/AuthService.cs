using CarManagement.Domain.Interfaces;

namespace CarManagement.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IEmailService _emailService;
        public AuthService(IUserRepository userRepository,IEmailService emailService)
        {
            _userRepo = userRepository;
            _emailService = emailService;
        }
        public async Task<bool> LoginAndSendOtp(string email, string password)
        {
            var user = await _userRepo.GetByEmailAsync(email);
            if (user == null || !_userRepo.Verify(password, user.PasswordHash))
                return false;

            var code = new Random().Next(100000, 999999).ToString();
            user.OtpCode = code;
            user.OtpExpiryTime = DateTime.UtcNow.AddMinutes(5);
            await _userRepo.UpdateAsync(user);
            await _emailService.SendEmailAsync(user.Email, "Login Code", $"your code is: {code}");
            return true;
        }

        public async Task<string?> VerifyOtpAndGetToken(string email, string code)
        {
            var user = await _userRepo.GetByEmailAsync(email);
            if (user == null || user.OtpCode != code || user.OtpExpiryTime < DateTime.UtcNow)
                return null;

            user.OtpCode = null;
            user.OtpExpiryTime = null;
            await _userRepo.UpdateAsync(user);
            return _userRepo.Generate(user);
        }
    }
}
