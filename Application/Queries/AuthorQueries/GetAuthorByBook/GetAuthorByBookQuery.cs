using Application.Dtos.AuthorDtos;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAuthorByBook
{
    public class GetAuthorByBookQuery : IRequest<AuthorByBookDto>
    {
        public string? BookTitle { get; set; }
        public GetAuthorByBookQuery(string bookTitle)
        {
            BookTitle = bookTitle;
        }

    }
}