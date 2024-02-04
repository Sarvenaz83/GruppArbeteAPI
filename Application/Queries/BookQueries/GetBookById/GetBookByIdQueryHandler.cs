using Application.Dtos.BookDtos;
using Domain.Models;
using Infrastructure.Repository.BookRepository;
using MediatR;

namespace Application.Queries.BookQueries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookByIdDto>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        public async Task<BookByIdDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var book = await _bookRepository.GetBookByIdAsync(request.Id);
                if (book == null)
                {
                    throw new KeyNotFoundException($"No book found with ID {request.Id}");
                }
                var bookDto = new BookByIdDto
                {
                    BookTitle = book.Title,
                    AuthorName = book.Author?.AuthorName,
                    Genre = book.Genre,
                    PubYear = book.PubYear,
                    Pages = book.Pages,
                    Rating = book.Rating,
                    Summary = book.Summary
                };

                return bookDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while get book by id.", ex);
            }
        }
    }
}
