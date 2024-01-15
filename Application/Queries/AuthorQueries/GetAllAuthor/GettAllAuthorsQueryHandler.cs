using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAllAuthor
{
    public class GettAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GettAllAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            List<Author> allAuthorFromHarryPotterContext = await _authorRepository.GetAllAuthorsAsync();
            List<Author> sortedAuthors = allAuthorFromHarryPotterContext.OrderBy(author => author.AuthorName).ToList();
            return allAuthorFromHarryPotterContext;
        }
    }
}
