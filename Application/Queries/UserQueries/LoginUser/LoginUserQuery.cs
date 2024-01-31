using MediatR;

namespace Application.Queries.UserQueries.LoginUser
{
    public class LoginUserQuery : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
