using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands.RegisterUser
{
    public class RegisterUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
