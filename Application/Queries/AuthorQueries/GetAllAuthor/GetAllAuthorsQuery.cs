using Domain.Models;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAllAuthor
{
    public class GetAllAuthorsQuery : IRequest<List<Author>>
    {
    }
}
