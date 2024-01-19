using Domain.Models;
using MediatR;

namespace Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Book>
    {
        public DeleteBookCommand(Guid bookId)
        {
            BookId = bookId;
        }

        public Guid BookId { get; }
    }
}

