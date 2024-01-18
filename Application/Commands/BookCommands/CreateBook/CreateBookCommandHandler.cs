using Domain.Models;
using Infrastructure.Repository.BookRepository;
using MediatR;

namespace Application.Commands.BookCommands.CreateBook
{
    public class AddBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book bookToCreate = new()
            {
                BookId = Guid.NewGuid(),
                Title = request.NewBook.Title,
                AuthorId = request.NewBook.AuthorId,
                Genre = request.NewBook.Genre,
                PubYear = request.NewBook.PubYear,
                Pages = request.NewBook.Pages,
                StockBalance = request.NewBook.StockBalance,
                Rating = request.NewBook.Rating,
                Summary = request.NewBook.Summary,
            };

            await _bookRepository.CreateBookAsync(bookToCreate);

            return bookToCreate;
        }
    }
}
