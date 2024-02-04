using Application.Dtos.BookDtos;
using Domain.Models;
using Infrastructure.Repository.BookRepository;
using MediatR;

namespace Application.Queries.BookQueries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<GetAllBooksDto>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<List<GetAllBooksDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Book> allBooksFromHarryPotterContext = await _bookRepository.GetAllBooksAsync();
                var allBooksFromDto = allBooksFromHarryPotterContext.Select(b => new GetAllBooksDto
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    AuthorName = b.Author!.AuthorName,
                    Genre = b.Genre,
                    PubYear = b.PubYear,
                    Pages = b.Pages,
                    Rating = b.Rating,
                    Summary = b.Summary

                }).ToList();
                return allBooksFromDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting books", ex);
            }

        }
    }
}
