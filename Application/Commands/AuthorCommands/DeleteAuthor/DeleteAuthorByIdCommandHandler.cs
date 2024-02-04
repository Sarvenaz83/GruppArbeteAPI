using Application.Dtos.AuthorDtos;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Commands.AuthorCommands.DeleteAuthor
{
    public class DeleteAuthorByIdCommandHandler : IRequestHandler<DeleteAuthorByIdCommand, DeleteAuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorByIdCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<DeleteAuthorDto> Handle(DeleteAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            var deletedAuthor = await _authorRepository.DeleteAuthorByIdAsync(request.AuthorId);
            if (deletedAuthor == null)
            {
                throw new KeyNotFoundException("Author not found.");
            }

            var deleteAuthorDto = new DeleteAuthorDto
            {
                AuthorId = deletedAuthor.AuthorId,
                AuthorName = deletedAuthor.AuthorName,
                Message = $"Author '{deletedAuthor.AuthorName}' and their books have been removed from the database."
            };

            return deleteAuthorDto;
        }

    }
}
