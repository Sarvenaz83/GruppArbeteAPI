using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorByIdCommandHandler : IRequestHandler<DeleteAuthorByIdCommand, bool>
    {

        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorByIdCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<bool> Handle(DeleteAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            var authorToDelete = await _authorRepository.GetAuthorByIdAsync(request.AuthorId);
            if (authorToDelete == null)
            {
                return false;
            }

            await _authorRepository.DeleteAuthorByIdAsync(request.AuthorId);
            return true;
        }
    }
}
