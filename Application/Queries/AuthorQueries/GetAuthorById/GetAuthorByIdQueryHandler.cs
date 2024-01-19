using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            Author wantedAuthor = await _authorRepository.GetAuthorByIdAsync(request.AuthorId);

            if (wantedAuthor == null)
            {
                throw new KeyNotFoundException($"Author not found by this ID: {request.AuthorId}");
            }
            else
            {
                return wantedAuthor;
            }
        }
    }
}
