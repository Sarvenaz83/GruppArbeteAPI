using Application.Dtos;
using MediatR;

namespace Application.Queries.Author.GetAllAutors
{
    public class GetAllAuthorsQuery : IRequest<List<AuthorDto>>
    {
    }
}
