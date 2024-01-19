// DeleteUserByIdCommand
using System;
using Domain.Models;
using MediatR;

namespace Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserByIdCommand : IRequest<User>
    {
        public Guid Id { get; }

        public DeleteUserByIdCommand(Guid id)
        {

            Id = id;

        }

    }
}

