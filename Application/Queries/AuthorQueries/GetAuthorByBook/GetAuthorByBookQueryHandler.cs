using Application.Dtos.AuthorDtos;
using Application.Queries.AuthorQueries.GetAuthorByBook;
using Infrastructure.Repository.AuthorRepository;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAuthorByBookCreate
{
    public class GetAuthorByBookQueryHandler : IRequestHandler<GetAuthorByBookQuery, AuthorByBookDto>
    {
        private readonly IAuthorRepository _authorRepository;
        public GetAuthorByBookQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<AuthorByBookDto> Handle(GetAuthorByBookQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var authors = await _authorRepository.GetAuthorByBookAsync(request.BookTitle);
                if (authors != null)
                {
                    var getAuthorByBookDto = new AuthorByBookDto { AuthorName = authors!.AuthorName };
                    return getAuthorByBookDto;
                }
                return null!;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while get author by title.", ex);
            }
        }
    }
}