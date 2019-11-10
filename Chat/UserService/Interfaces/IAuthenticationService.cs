using Microsoft.IdentityModel.Tokens;
using Chat.User.Model;

namespace Chat.User.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserResponse user);
    }
}
