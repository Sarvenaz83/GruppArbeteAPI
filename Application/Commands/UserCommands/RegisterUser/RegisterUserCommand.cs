using Application.Dtos.UserDtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.UserCommands.RegisterUser
{
    public class RegisterUserCommand : IRequest<User>
    {
        public RegisterUserCommand(NewUserDto newUser)
        {
            NewUser = newUser;
        }
        public NewUserDto NewUser { get; }
    }
}
