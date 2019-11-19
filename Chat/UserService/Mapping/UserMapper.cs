using Chat.Db.Entities;
using Chat.User.Model;

namespace Chat.User.Mapping
{
    public static class UserMapper
    {
        public static Db.Entities.User ToUser(this UserResponse entity)
        {
            return new Db.Entities.User()
            {
                Id = entity.Id,
                Role = entity.Role,
                Token = entity.Token,
                Username = entity.Username
            };
        }
    }
}
