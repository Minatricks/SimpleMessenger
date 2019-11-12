using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Message.Model;

namespace Chat.Message.Interfaces
{
    public interface IMessageService
    {
        Task<int> SendMessage(MessageDto message);

        Task<List<MessageDto>> GetMessages(int recepientId);
    }
}
