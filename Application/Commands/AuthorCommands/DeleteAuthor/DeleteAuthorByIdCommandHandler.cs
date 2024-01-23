using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorByIdCommandHandler : IRequestHandler<DeleteAuthorByIdCommand, Author>
    {

        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorByIdCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
        }

        public async Task<Author> Handle(DeleteAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            var authorToDelete = await _authorRepository.GetAuthorByIdAsync(request.AuthorId);
            if (authorToDelete != null)
            {
                await _authorRepository.DeleteAuthorByIdAsync(request.AuthorId);
                return authorToDelete;
            }
            return null;
        }

    }
}
