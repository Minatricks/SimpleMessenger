using Chat.Message.Interfaces;
using Chat.Message.Model;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.Message
{
    public class MessageHub : Hub
    {
        private readonly IMessageService _messageService;

        public MessageHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task NotifyThatMessageSended(MessageResponse message)
        {
            await Clients.All.SendAsync("ReciveMessage", message);
        }
    }
}
