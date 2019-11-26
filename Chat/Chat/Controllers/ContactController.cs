using System.Threading.Tasks;
using Chat.Contacts;
using Chat.Contacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(ContactPaginationRequest request)
        {
            var result = await _contactService.GetMyContactsAsync(request);
            return Ok(result);
        }
    }
}