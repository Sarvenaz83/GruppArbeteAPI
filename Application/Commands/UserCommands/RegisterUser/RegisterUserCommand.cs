using Domain.Models;
using MediatR;

namespace Application.Commands.UserCommands.RegisterUser
{
    public class RegisterUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
