using Chat.User.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.User.Interfaces
{
    public interface IUserService
    {
        Task<int> RegisterUser(string username, string password);

        UserResponse Get(string username, string password);

        IEnumerable<UserResponse> GetAll();
    }
}
