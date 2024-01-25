using Application.Dtos;
using Domain.Models;
using Infrastructure.Repository.UserRepository;
using MediatR;

namespace Application.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetAllUsersDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                var getAllUsersDtos = users.Select(u => new GetAllUsersDto
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    Email = u.Email,
                    TelephoneNumber = u.TelephoneNumber,
                    FirstName = u.FirstName,
                    SurName = u.SurName,
                }).ToList();

                return getAllUsersDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ett fel inträffade vid hämtning av användarinformation.");
            }
        }
    }
}

