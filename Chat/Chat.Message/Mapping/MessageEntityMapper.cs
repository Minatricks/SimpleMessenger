using Chat.Db.Entities;
using Chat.Message.Model;

namespace Chat.Message.Mapping
{
    public static class MessageEntityMapper
    {
        public static Messages ToMessage(this MessageDto entity)
        {
            return new Messages()
            {
                Id = entity.Id,
                TextMessage = entity.TextMessage,
                IdRecipient = entity.IdRecipient,
                IdSender = entity.IdSender,
                DateTime = entity.DateTime,
            };
        }
    }
}
