using Domain.Models;
using Infrastructure.Repository.BookRepository;
using MediatR;

namespace Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookByIdCommandHandler : IRequestHandler<UpdateBookByIdCommand, Book>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookByIdCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(UpdateBookByIdCommand request, CancellationToken cancellationToken)
        {
            var bookToUpdate = await _bookRepository.GetBookByIdAsync(request.BookId);

            if (bookToUpdate == null)
            {
                return null!;
            }

            bookToUpdate.Title = request.UpdatedBook.Title;
            bookToUpdate.AuthorId = request.UpdatedBook.AuthorId;
            bookToUpdate.Genre = request.UpdatedBook.Genre;
            bookToUpdate.PubYear = request.UpdatedBook.PubYear;
            bookToUpdate.Pages = request.UpdatedBook.Pages;
            //bookToUpdate.StockBalance = request.UpdatedBook.StockBalance;
            bookToUpdate.Rating = request.UpdatedBook.Rating;
            bookToUpdate.Summary = request.UpdatedBook.Summary;

            await _bookRepository.UpdateBookByIdAsync(bookToUpdate);

            return bookToUpdate;
        }
    }
}
