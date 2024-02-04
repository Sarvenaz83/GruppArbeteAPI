using Application.Dtos.UserDtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserByIdCommand : IRequest<User>
    {
        public Guid UserId { get; set; }
        public UpdateUserDto UpdateUserDto { get; set; }
    }
}
