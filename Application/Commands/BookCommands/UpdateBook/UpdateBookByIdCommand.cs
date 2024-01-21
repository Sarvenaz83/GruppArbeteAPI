using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookByIdCommand : IRequest<Book>
    {
        public UpdateBookByIdCommand(Guid bookId, BookDto updatedBook)
        {
            BookId = bookId;
            UpdatedBook = updatedBook;
        }
        public Guid BookId { get; }
        public BookDto UpdatedBook { get; set; }
    }
}
