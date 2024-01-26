using Domain.Models;
using MediatR;

namespace Application.Queries.UserQueries.LoginUser
{
    public class LoginUserQuery : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
