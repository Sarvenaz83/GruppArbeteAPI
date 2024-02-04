using Application.Dtos.BookDtos;
using Domain.Models;
using Infrastructure.Repository.BookRepository;
using MediatR;

namespace Application.Queries.BookQueries.GetBookByTitle
{
    public class GetBookByTitleQueryHandler : IRequestHandler<GetBookByTitleQuery, List<GetBookByTitleDto>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByTitleQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<List<GetBookByTitleDto>> Handle(GetBookByTitleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Book> booksByTitleFromHarryPotterContext = await _bookRepository.GetBooksByTitleContainsAsync(request.TitleSubstring);
                var bookByTitle = booksByTitleFromHarryPotterContext.Select(b => new GetBookByTitleDto
                {
                    Title = b.Title,
                    Genre = b.Genre,
                    PubYear = b.PubYear,
                    Pages = b.Pages,
                    Rating = b.Rating,
                    Summary = b.Summary,

                }).ToList();
                return bookByTitle;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting books", ex);
            }

        }
    }
}
