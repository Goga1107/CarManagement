using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces;
using MediatR;

namespace CarManagement.Application.Users.Commands.Register
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var hashedPassword = _userRepository.Hash(request.Password);
            User user = new User
            {
                FullName = request.FullName,
                CreatedAt = DateTime.UtcNow,
                Email = request.Email,
                PasswordHash = hashedPassword,
            };
            var result = await _userRepository.RegisterUser(user, cancellationToken);
            return result.Id;
        }
    }
}
