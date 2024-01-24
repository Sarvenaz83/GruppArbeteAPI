using Domain.Models;
using MediatR;

namespace Application.Queries.UserQueries
{
    public class LoginUserQuery : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
