using Domain.Models;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Queries.Author.GetAllAutors
{
    
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorModel>>
    {
        private readonly IAuthorRepository _authorRepository;
        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<List<AuthorModel>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAllAuthorsAsync();
        }
    }
}
