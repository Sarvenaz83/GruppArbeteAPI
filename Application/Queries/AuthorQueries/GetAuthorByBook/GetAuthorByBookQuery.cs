using Domain.Models;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAuthorByBook
{
    public class GetAuthorByBookQuery : IRequest<Author>
    {
        public GetAuthorByBookQuery(string bookTitle)
        {
            BookTitle = bookTitle;
        }
        public string BookTitle { get; }
    }
}