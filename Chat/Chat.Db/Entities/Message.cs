using System;

namespace Chat.Db.Entities
{
    public class Message
    {
        public Guid Id { get; set; }

        public string TextMessage { get; set; }

        public DateTime DateAndTime { get; set; }


        public int IdSender { get; set; }

        public User SenderUser { get; set; }


        public int IdRecipient { get; set; }

        public User RecipientUser { get; set; }
    }
}
