using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Message.Model;

namespace Chat.Message.Interfaces
{
    public interface IMessageService
    {
        Task<int> SendMessage(MessageResponse message);

        Task<List<MessageResponse>> GetMessages(int recepientId);
    }
}
