using Application.Dtos.AuthorDtos;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAuthorByBook
{
    public class GetAuthorByBookQuery : IRequest<AuthorByBookDto>
    {
        public GetAuthorByBookQuery(string bookTitle)
        {
            Title = bookTitle;
        }
        public string? Title { get; set; }
    }
}