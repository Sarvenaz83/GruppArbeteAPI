using Domain.Models;
using Infrastructure.Repository.BookRepository;
using MediatR;

namespace Application.Queries.BookQueries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book?>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var wantedBook = await _bookRepository.GetBookByIdAsync(request.Id);
            if (wantedBook != null)
                return wantedBook;

            else
                return null;
        }
    }
}
