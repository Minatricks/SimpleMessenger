﻿using Chat.Db.Entities;
using Chat.Message.Model;

namespace Chat.Message.Mapping
{
    public static class MessangeResponseMapper
    {
        public static MessageResponse ToMessageResponse(this Messages entity)
        {
            return new MessageResponse()
            {
                Id = entity.Id,
                TextMessage = entity.TextMessage,
                IdRecipient = entity.IdRecipient,
                IdSender = entity.IdSender,
                DateTime = entity.DateTime
            };
        }
    }
}