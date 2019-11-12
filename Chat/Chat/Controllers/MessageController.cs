using System.Threading.Tasks;
using Chat.Message;
using Chat.Message.Interfaces;
using Chat.Message.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.Controllers
{
    [Authorize]
    [Route("message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly IMessageService _messageService;

        public MessageController(IHubContext<MessageHub> hubContext, IMessageService messageService)
        {
            _hubContext = hubContext;
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MessageDto message)
        {
            await _messageService.SendMessage(message);
            await _hubContext.Clients.All.SendAsync("notify", message);
            return Ok();
        }
    }
}
