using Chat.Message.Model;

namespace Chat.Message.Mapping
{
    public static class MessageEntityMapper
    {
        public static Db.Entities.Message ToMessage(this MessageDto entity)
        {
            return new Db.Entities.Message()
            {
                Id = entity.Id,
                TextMessage = entity.TextMessage,
                IdRecipient = entity.IdRecipient,
                IdSender = entity.IdSender,
                DateAndTime = entity.DateTime,
            };
        }
    }
}
