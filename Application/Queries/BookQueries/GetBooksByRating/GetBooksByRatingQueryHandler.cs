using Domain.Models;
using Infrastructure.Repository.BookRepository;
using MediatR;

namespace Application.Queries.BookQueries.GetBooksByRating
{
    public class GetBooksByRatingQueryHandler : IRequestHandler<GetBooksByRatingQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksByRatingQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<List<Book>> Handle(GetBooksByRatingQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksByRatingAsync(request.MinimumRating);


            if (!books.Any())
            {
                return new List<Book>();
            }
            return books;
        }
    }
}
