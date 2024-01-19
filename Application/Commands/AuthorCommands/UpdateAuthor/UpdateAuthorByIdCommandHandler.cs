using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorByIdCommandHandler : IRequestHandler<UpdateAuthorByIdCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorByIdCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
        }

        public async Task<Author> Handle(UpdateAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            var authorToUpdate = await _authorRepository.GetAuthorByIdAsync(request.AuthorId);

            if (authorToUpdate == null)
            {
                return null!;
            }
            authorToUpdate.AuthorName = request.UpdatedAuthor.AuthorName;

            await _authorRepository.UpdateAuthorByIdAsync(request.AuthorId, authorToUpdate);
            return authorToUpdate;
        }
    }
}
