using Chat.Db;
using Chat.User.Interfaces;
using Chat.User.Mapping;
using Chat.User.Model;
using System.Collections.Generic;
using System.Linq;

namespace Chat.User
{
    public class UserService : IUserService
    {
        private readonly IChatDbContext _chatDbContext;

        public UserService(IChatDbContext dbContext)
        {
            _chatDbContext = dbContext;
        }

        public UserResponse Get(string username, string password)
        {
            var user = _chatDbContext.Users.First(x => x.Username == username && x.Password == password);
            return user.ToUserResponse();
        }

        public IEnumerable<UserResponse> GetAll()
        {
            return _chatDbContext.Users.Select(x => x.ToUserResponse());
        }
    }
}
