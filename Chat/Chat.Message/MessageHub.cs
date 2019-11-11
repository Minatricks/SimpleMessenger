using Chat.Message.Interfaces;
using Chat.Message.Model;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.Message
{
    public class MessageHub : Hub, IMessageHub
    {
        public async Task Notify(MessageResponse message)
        {
            await Clients.All.SendAsync("notify", message);
        }
    }
}
