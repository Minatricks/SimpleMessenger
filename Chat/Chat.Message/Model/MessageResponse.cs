using System;

namespace Chat.Message.Model
{
   public class MessageDto
    {
        public string Id { get; set; }

        public string TextMessage { get; set; }

        public DateTime DateTime { get; set; }

        public int IdSender { get; set; }

        public int IdRecipient { get; set; }
    }
}
