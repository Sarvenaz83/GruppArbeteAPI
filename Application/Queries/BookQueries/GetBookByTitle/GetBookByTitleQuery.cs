using Domain.Models;
using MediatR;

namespace Application.Queries.BookQueries.GetBookByTitle
{
    public class GetBookByTitleQuery : IRequest<List<Book>>
    {
        public string TitleSubstring { get; set; }
        public GetBookByTitleQuery(string titleSubstring) { TitleSubstring = titleSubstring; }
    }
}
