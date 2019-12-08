using Chat.Message.Model;
using System;

namespace Chat.Message.Mapping
{
    public static class MessageEntityMapper
    {
        public static Db.Entities.Message ToMessage(this MessageDto entity)
        {
            var message = new Db.Entities.Message()
            {
                TextMessage = entity.TextMessage,
                IdRecipient = entity.IdRecipient,
                IdSender = entity.IdSender,
                DateAndTime = entity.DateTime,
            };

            if(entity.Id != null)
            {
                message.Id = new Guid(entity.Id);
            }

            return message;
        }
    }
}
