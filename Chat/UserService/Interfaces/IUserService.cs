using Chat.User.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.User.Interfaces
{
    public interface IUserService
    {
        Task<int> RegisterUser(string username, string password);

        Task<UserResponse> Get(string username, string password);

        IEnumerable<UserResponse> GetAll();

        Task<int> UpdateUserToken(int userId, string token);
    }
}
