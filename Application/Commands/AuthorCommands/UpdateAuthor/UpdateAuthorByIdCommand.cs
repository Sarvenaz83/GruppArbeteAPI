using Application.Dtos.AuthorDtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorByIdCommand : IRequest<Author>
    {
        public UpdateAuthorByIdCommand(Guid authorId, AuthorDto updatedAuthor)
        {
            AuthorId = authorId;
            UpdatedAuthor = updatedAuthor;

        }
        public Guid AuthorId { get; }
        public AuthorDto UpdatedAuthor { get; set; }

    }
}
