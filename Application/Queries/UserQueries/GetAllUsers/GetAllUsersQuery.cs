using Application.Dtos.UserDtos;
using Domain.Models;
using MediatR;

namespace Application.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<GetAllUsersDto>>
    {
    }
}

