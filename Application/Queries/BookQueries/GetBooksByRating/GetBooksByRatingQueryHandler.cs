using Application.Dtos;
using Infrastructure.Repository.BookRepository;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Queries.BookQueries.GetBooksByRating
{
    public class GetBooksByRatingQueryHandler : IRequestHandler<GetBooksByRatingQuery, List<GetBooksByRatingDto>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksByRatingQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<List<GetBooksByRatingDto>> Handle(GetBooksByRatingQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksByRatingAsync(request.MinimumRating);
            if (!books.IsNullOrEmpty())
            {
                var booksByRatingDto = books.Select(b => new GetBooksByRatingDto
                {
                    Title = b.Title!,
                    Rating = b.Rating,
                    AuthorName = b.Author!.AuthorName!
                }).ToList();
                return booksByRatingDto;
            }
            else
                return null;
        }
    }
}
