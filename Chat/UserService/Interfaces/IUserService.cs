using Chat.User.Model;
using System.Collections.Generic;

namespace Chat.User.Interfaces
{
    public interface IUserService
    {
        UserResponse Get(string username, string password);

        IEnumerable<UserResponse> GetAll();
    }
}
