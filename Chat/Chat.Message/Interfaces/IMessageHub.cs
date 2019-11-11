using Chat.Message.Model;
using System.Threading.Tasks;

namespace Chat.Message.Interfaces
{
    public interface IMessageHub 
    {
        Task Notify(MessageResponse message);
    }
}
