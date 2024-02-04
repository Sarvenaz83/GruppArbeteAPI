using Application.Dtos.AuthorDtos;
using MediatR;

namespace Application.Queries.AuthorQueries.GetAllAuthor
{
    public class GetAllAuthorsQuery : IRequest<List<GetAllAuthorsDto>>
    {
    }
}
