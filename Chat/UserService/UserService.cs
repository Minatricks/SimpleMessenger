using System;
using Chat.Db;
using Chat.User.Interfaces;
using Chat.User.Mapping;
using Chat.User.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Chat.Exceptions;
using System.Linq.Expressions;

namespace Chat.User
{
    public class UserService : IUserService
    {
        private readonly IChatDbContext _chatDbContext;

        public UserService(IChatDbContext dbContext)
        {
            _chatDbContext = dbContext;
        }

        public async Task<UserResponse> Get(string username, string password)
        {
            var user = await FindUser(x => x.Username == username && x.Password == password, parameters: username);
            return user.ToUserResponse();
        }

        public async Task<int> UpdateUserToken(int userId, string token)
        {
            var user = await FindUser(x => x.Id == userId, parameters: userId);

            user.Token = token;
            _chatDbContext.Entry(user).State = EntityState.Modified;
            return await _chatDbContext.SaveChangesAsync();
        }

        public async Task<int> RegisterUser(string username, string password)
        {
            var searchResult = await _chatDbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (searchResult != null)
            {
                throw new IncorrectParametersException("User already exist.", username);
            }

            var user = new Db.Entities.User()
            {
                Username = username,
                Password = password,
                Role = Roles.User,
            };

            var profile = new UsersProfile()
            {
                User = user
            };

            _chatDbContext.Users.Add(user);
            _chatDbContext.Profiles.Add(profile);
            return await _chatDbContext.SaveChangesAsync();
        }

        public IEnumerable<UserResponse> GetAll()
        {
            return _chatDbContext.Users.Select(x => x.ToUserResponse());
        }

        private async Task<Db.Entities.User> FindUser(
            Expression<Func<Db.Entities.User, bool>> expression,
            string exceptionMessage = "User not found",
            object parameters = null)
        {
            var user = await _chatDbContext.Users.FirstOrDefaultAsync(expression);
            if (user == null)
            {
                throw new IncorrectParametersException(exceptionMessage, parameters);
            }

            return user;
        }
    }
}
