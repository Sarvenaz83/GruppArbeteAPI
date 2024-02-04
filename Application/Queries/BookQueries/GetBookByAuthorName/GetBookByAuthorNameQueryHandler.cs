using Application.Dtos.BookDtos;
using Infrastructure.Repository.BookRepository;
using MediatR;

namespace Application.Queries.BookQueries.GetBookByAuthorName
{
    public class GetBookByAuthorNameQueryHandler : IRequestHandler<GetBookByAuthorNameQuery, List<BookByAuthorNameDto>>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByAuthorNameQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookByAuthorNameDto>> Handle(GetBookByAuthorNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var books = await _bookRepository.GetBooksByAuthorName(request.AuthorName!);
                var getBooksByAuthorNameDto = books.Select(book => new BookByAuthorNameDto
                {
                    Title = book.Title,
                    AuthorName = book.Author.AuthorName,
                    Genre = book.Genre,
                    PubYear = book.PubYear.Value.Year,
                    Pages = book.Pages,
                    Rating = book.Rating,
                    Summary = book.Summary,
                    Price = book.Price
                }).ToList();
                return getBooksByAuthorNameDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while get book by author name.", ex);
            }

        }
    }
}
