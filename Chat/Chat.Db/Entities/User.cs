using System.Collections.Generic;

namespace Chat.Db.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }


        public UsersProfile Profile { get; set; }

        public ICollection<Contact> MyContacts { get; set; }

        public ICollection<Contact> IinFriendContacts { get; set; }

        public ICollection<Message> SendMessages { get; set; }

        public ICollection<Message> ReceivedMessages { get; set; }
    }
}
