using Application.Dtos.AuthorDtos;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorByIdCommand : IRequest<DeleteAuthorDto>
    {

        public DeleteAuthorByIdCommand(Guid authorId)
        {
            AuthorId = authorId;
        }
        public Guid AuthorId { get; }
    }
}
