using Domain.Models;
using MediatR;

namespace Application.Queries.BookQueries.GetBookByAuthorName
{
    public class GetBookByAuthorNameQuery : IRequest<List<Book>>
    {
        public GetBookByAuthorNameQuery(string authorName)
        {
            AuthorName = authorName;
        }
        public string AuthorName { get; }
    }
}
