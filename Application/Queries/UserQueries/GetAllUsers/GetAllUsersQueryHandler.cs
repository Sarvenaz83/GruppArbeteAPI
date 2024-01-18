using Domain.Models;
using Infrastructure.Repository.UserRepository;
using MediatR;

namespace Application.Queries.UserQueries.GetAllUsers
{
    public class GettAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GettAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> allUsersFromHarryPotterContext = await _userRepository.GetAllUsersAsync();
            List<User> sortedUsers = allUsersFromHarryPotterContext.OrderBy(user => user.UserName).ToList();
            return allUsersFromHarryPotterContext;
        }
    }
}

