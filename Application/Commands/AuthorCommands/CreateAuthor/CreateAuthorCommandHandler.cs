using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Commands.AuthorCommands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author newAuthor = new()
            {
                AuthorId = Guid.NewGuid(),
                AuthorName = request.NewAuthor.AuthorName
            };
            await _authorRepository.CreateAuthorAsync(newAuthor);
            return newAuthor;

        }
    }
}
