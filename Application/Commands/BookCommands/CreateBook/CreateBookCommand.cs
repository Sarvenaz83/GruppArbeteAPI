using Application.Dtos.BookDtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.BookCommands.CreateBook
{
    public class CreateBookCommand : IRequest<Book>
    {
        public CreateBookCommand(BookDto newBook)
        {
            NewBook = newBook;
        }
        public BookDto NewBook { get; }

    }
}
