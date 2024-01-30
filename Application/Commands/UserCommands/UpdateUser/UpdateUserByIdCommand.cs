using Application.Dtos.UserDtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserByIdCommand : IRequest<User>
    {
        public Guid UserId { get; set; }
        public UpdateUserDto UpdateUserDto { get; set; }
    }
}
