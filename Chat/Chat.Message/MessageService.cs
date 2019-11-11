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

        public async Task<int> SendMessage(MessageResponse message)
        {
            _chatDbContext.Messages.Add(message.ToMessage());
            return await _chatDbContext.SaveChangesAsync();
        }

        public async Task<List<MessageResponse>> GetMessages(int recepientId)
        {
            return await _chatDbContext.Messages
                .Where(x => x.IdRecipient == recepientId)
                .Select(x => x.ToMessageResponse())
                .ToListAsync();
        }
    }
}
