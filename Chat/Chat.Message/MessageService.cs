using Chat.Db;
using Chat.Message.Interfaces;
using Chat.Message.Mapping;
using Chat.Message.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Message
{
    public class MessageService : IMessageService
    {
        private readonly IChatDbContext _chatDbContext;

        public MessageService(IChatDbContext dbContext)
        {
            _chatDbContext = dbContext;
        }

        public async Task<int> SendMessage(MessageDto message)
        {
            _chatDbContext.Messages.Add(message.ToMessage());
            return await _chatDbContext.SaveChangesAsync();
        }

        public async Task<List<MessageDto>> GetMessages(int recipientId)
        {
            return await _chatDbContext.Messages
                .Where(x => x.IdRecipient == recipientId)
                .Select(x => x.ToMessageResponse())
                .ToListAsync();
        }

        public async Task<List<MessageDto>> GetMessages(int recipientId, int senderId)
        {
            var sendMessages = await _chatDbContext.Messages
                .Where(x => x.IdRecipient == recipientId)
                .Where(x => x.IdSender == senderId)
                .OrderBy(x => x.DateAndTime)
                .Select(x => x.ToMessageResponse())
                .ToListAsync();

            var getMessages = await _chatDbContext.Messages
                .Where(x => x.IdRecipient == senderId)
                .Where(x => x.IdSender == recipientId)
                .OrderBy(x => x.DateAndTime)
                .Select(x => x.ToMessageResponse())
                .ToListAsync();
            sendMessages.AddRange(getMessages);

            return sendMessages.OrderBy(x => x.DateTime).ToList();
        }

        public async Task<MessageDto> GetLastMessage(int recipientId, int senderId)
        {
            var message = await _chatDbContext.Messages
                .Where(x => x.IdRecipient == recipientId)
                .Where(x => x.IdSender == senderId)
                .OrderByDescending(x => x.DateAndTime)
                .FirstOrDefaultAsync();

            var messageSend = await _chatDbContext.Messages
                .Where(x => x.IdRecipient == senderId)
                .Where(x => x.IdSender == recipientId)
                .OrderByDescending(x => x.DateAndTime)
                .FirstOrDefaultAsync();

           if (messageSend?.DateAndTime > message?.DateAndTime)
            {
                messageSend.TextMessage = $"You:{messageSend.TextMessage}";
                return messageSend.ToMessageResponse();
            }

            return message.ToMessageResponse();
        }
    }
}
