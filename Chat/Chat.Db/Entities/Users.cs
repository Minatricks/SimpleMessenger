using System.Collections.Generic;

namespace Chat.Db.Entities
{
    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }


        public UsersProfile Profile { get; set; }

        public ICollection<Contacts> Contacts { get; set; }

        public ICollection<Messages> SendMessages { get; set; }

        public ICollection<Messages> ReceivedMessages { get; set; }
    }
}
