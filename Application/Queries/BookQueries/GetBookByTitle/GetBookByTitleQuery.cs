using Application.Dtos.BookDtos;
using MediatR;

namespace Application.Queries.BookQueries.GetBookByTitle
{
    public class GetBookByTitleQuery : IRequest<List<GetBookByTitleDto>>
    {
        public string TitleSubstring { get; set; }
        public GetBookByTitleQuery(string titleSubstring)
        {
            TitleSubstring = titleSubstring;
        }
    }
}
