using MediatR;
using Domain.Models;

namespace Application.Queries.Author.GetAllAutors
{
    public class GetAllAuthorsQuery : IRequest<List<AuthorModel>>
    {
    }
}
