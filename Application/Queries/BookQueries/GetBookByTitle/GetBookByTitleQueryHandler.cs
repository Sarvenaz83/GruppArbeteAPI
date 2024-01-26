using Domain.Models;
using Infrastructure.Repository.BookRepository;
using MediatR;

namespace Application.Queries.BookQueries.GetBookByTitle
{
    public class GetBookByTitleQueryHandler : IRequestHandler<GetBookByTitleQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByTitleQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<List<Book>> Handle(GetBookByTitleQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBooksByTitleContainsAsync(request.TitleSubstring);
        }
    }
}
