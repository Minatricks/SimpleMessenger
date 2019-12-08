using System.Collections.Generic;
using System.Threading.Tasks;
using Chat.Contacts;
using Chat.Contacts.Models;
using Chat.User.Interfaces;
using Chat.User.Model;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IUserService _userService;


        public ContactController(IContactService contactService, IUserService userService)
        {
            _contactService = contactService;
            _userService = userService;
        }
          
        [HttpGet]
        public async Task<IActionResult> Get(ContactPaginationRequest request)
        {
            var friends = await _contactService.GetMyContactsAsync(request);
            var users = new List<UserResponse>();

            foreach(var friendId in friends.Data)
            {
                users.Add(await _userService.Get(friendId.FriendId));
            }

            return Ok(users);
        }
    }
}