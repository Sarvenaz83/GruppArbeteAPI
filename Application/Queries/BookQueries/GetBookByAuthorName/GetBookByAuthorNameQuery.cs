using Application.Dtos.BookDtos;
using MediatR;

namespace Application.Queries.BookQueries.GetBookByAuthorName
{
    public class GetBookByAuthorNameQuery : IRequest<List<BookByAuthorNameDto>>
    {
        public string? AuthorName { get; set; }
    }
}
