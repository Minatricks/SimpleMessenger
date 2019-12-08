using Chat.Db.Entities;
using Chat.Message.Model;

namespace Chat.Message.Mapping
{
    public static class MessangeResponseMapper
    {
        public static MessageDto ToMessageResponse(this Db.Entities.Message entity)
        {
            return new MessageDto()
            {
                Id = entity.Id.ToString(),
                TextMessage = entity.TextMessage,
                IdRecipient = entity.IdRecipient,
                IdSender = entity.IdSender,
                DateTime = entity.DateAndTime
            };
        }
    }
}
