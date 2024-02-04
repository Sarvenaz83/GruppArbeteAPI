using Domain.Models;
using Infrastructure.Repository.BookRepository;
using MediatR;
using System;
using System.Threading.Tasks;

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

            Book lastCreatedBook = null;
            string articleNumber = Guid.NewGuid().ToString();

            // Skapa det angivna antalet böcker
            for (int i = 0; i < request.Quantity; i++)
            {
                Book bookToCreate = new()
                {
                    BookId = Guid.NewGuid(),
                    Title = request.NewBookDto.Title,
                    AuthorId = request.NewBookDto.AuthorId,
                    Genre = request.NewBookDto.Genre,
                    PubYear = request.NewBookDto.PubYear,
                    Pages = request.NewBookDto.Pages,
                    Rating = request.NewBookDto.Rating,
                    Summary = request.NewBookDto.Summary,
                    ArticleNumber = articleNumber,
                    Price = request.NewBookDto.price
                };

                lastCreatedBook = await _bookRepository.CreateBookAsync(bookToCreate);
            }

            // Returnera det sista skapade bokexemplaret
            return lastCreatedBook;
        }


    }
}
