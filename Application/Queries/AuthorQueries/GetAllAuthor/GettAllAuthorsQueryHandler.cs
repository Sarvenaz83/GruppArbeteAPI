using Application.Dtos.AuthorDtos;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAllAuthor
{
    public class GettAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<GetAllAuthorsDto>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GettAllAuthorsQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<GetAllAuthorsDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Authors = await _authorRepository.GetAllAuthorsAsync();
                var getAllAuthorsDtos = Authors.Select(a => new GetAllAuthorsDto
                {
                    AuthorId = a.AuthorId,
                    AuthorName = a.AuthorName,

                }).ToList();

                return getAllAuthorsDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ett fel inträffade vid hämtning av användarinformation.");
            }
        }
    }
}
