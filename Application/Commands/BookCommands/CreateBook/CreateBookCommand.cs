using Application.Dtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
