using MediatR;
using Domain.Models;

namespace Application.Queries.AuthorQueries.GetAllAuthor
{
    public class GetAllAuthorsQuery : IRequest<List<Author>>
    {
    }
}
