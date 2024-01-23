using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAuthorByBook
{
    public class GetAuthorByBookQueryHandler : IRequestHandler<GetAuthorByBookQuery, Author>
    {
        private readonly IAuthorRepository _authorRepository;
        public GetAuthorByBookQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetAuthorByBookQuery request, CancellationToken cancellationToken)
        {
            var authorListByBookTitle = await _authorRepository.GetAuthorByBookAsync(request.BookTitle);
            return authorListByBookTitle;
        }
    }
}