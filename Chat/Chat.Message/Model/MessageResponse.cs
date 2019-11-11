namespace Chat.Message.Model
{
   public class MessageResponse
    {
        public string Id { get; set; }

        public string TextMessage { get; set; }

        public string DateTime { get; set; }

        public int IdSender { get; set; }

        public int IdRecipient { get; set; }
    }
}
