using MediatR;

namespace CarManagement.Application.Users.Commands.Register
{
    public record RegisterUserCommand(
        string FullName,
        string Email,
        string Password) : IRequest<int>;
}
