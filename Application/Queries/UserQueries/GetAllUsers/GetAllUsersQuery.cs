using Application.Dtos.UserDtos;
using MediatR;

namespace Application.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<GetAllUsersDto>>
    {
    }
}

