using Domain.Models;

namespace Application.Queries.UserQueries.LoginUser
{
    public interface ITokenGenerator
    {
        string JwtTokenGenerate(User user);
    }
}
