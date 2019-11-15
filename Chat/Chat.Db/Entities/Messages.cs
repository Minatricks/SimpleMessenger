using System;

namespace Chat.Db.Entities
{
    public class Messages
    {
        public string Id { get; set; }

        public string TextMessage { get; set; }

        public DateTime DateAndTime { get; set; }


        public int IdSender { get; set; }

        public Users SenderUser { get; set; }


        public int IdRecipient { get; set; }

        public Users RecipientUser { get; set; }
    }
}
