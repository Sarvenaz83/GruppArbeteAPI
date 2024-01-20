using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorByIdCommand : IRequest<bool>
    {
        public Guid AuthorId { get; set; }

        public DeleteAuthorByIdCommand(Guid authorId)
        {
            AuthorId = authorId;
        }
    }
}
