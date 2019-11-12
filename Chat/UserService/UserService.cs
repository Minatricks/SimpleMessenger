using System;
using Chat.Db;
using Chat.User.Interfaces;
using Chat.User.Mapping;
using Chat.User.Model;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Chat.Db.Entities;
using Microsoft.EntityFrameworkCore;

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
        public async Task<int> RegisterUser(string username, string password)
        {
            var searchResult = await _chatDbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (searchResult != null)
            {
                throw new Exception("User already exist");
            }

            var lastUserId = await _chatDbContext.Users.Select(x => x.Id).FirstOrDefaultAsync();

            var user = new Users()
            {
                Username = username,
                Password = password,
                Role = Roles.User,
                Id = lastUserId + 1
            };

            var profile = new UsersProfile()
            {
                Id = lastUserId + 1
            };

            _chatDbContext.Users.Add(user);
            _chatDbContext.Profiles.Add(profile);
           return await _chatDbContext.SaveChangesAsync();
        }

        public IEnumerable<UserResponse> GetAll()
        {
            return _chatDbContext.Users.Select(x => x.ToUserResponse());
        }
    }
}
