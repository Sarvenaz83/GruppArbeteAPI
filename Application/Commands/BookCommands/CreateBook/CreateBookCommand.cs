using Application.Dtos.BookDtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.BookCommands.CreateBook
{
    public class CreateBookCommand : IRequest<Book>
    {
        public BookDto NewBookDto { get; set; }
        public int Quantity { get; set; } // Antal exemplar av boken som ska skapas

        public CreateBookCommand(BookDto newBookDto, int quantity)
        {
            NewBookDto = newBookDto;
            Quantity = quantity;
        }
    }
}
