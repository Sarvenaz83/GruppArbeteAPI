using Domain.Models;
using Infrastructure.Repository.BookRepository;
using MediatR;

namespace Application.Queries.BookQueries.GetBookByAuthorName
{
    public class GetBookByAuthorNameQueryHandler : IRequestHandler<GetBookByAuthorNameQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByAuthorNameQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> Handle(GetBookByAuthorNameQuery request, CancellationToken cancellationToken)
        {
            var bookListByAuthorName = await _bookRepository.GetBooksByAuthorName(request.AuthorName);
            return bookListByAuthorName;
        }
    }
}
