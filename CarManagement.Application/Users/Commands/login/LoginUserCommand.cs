using MediatR;

namespace CarManagement.Application.Users.Commands.login
{
    public record LoginUserCommand(string email,string password) : IRequest<bool>;
}
