using Domain.Models;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorByIdCommand : IRequest<Author>
    {

        public DeleteAuthorByIdCommand(Guid authorId)
        {
            AuthorId = authorId;
        }
        public Guid AuthorId { get; }
    }
}
