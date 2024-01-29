using Application.Dtos.AuthorDtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.AuthorCommands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Author>
    {
        public CreateAuthorCommand(AuthorDto newAuthor)
        {
            NewAuthor = newAuthor;
        }
        public AuthorDto NewAuthor { get; }
    }
}
