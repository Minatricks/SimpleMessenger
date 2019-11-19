using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Chat.Api.Models;
using Chat.User.Interfaces;

namespace Chat.Api.Controllers
{
    [Route("user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IAuthenticationService _authenticationService;

        public UserController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }


        [AllowAnonymous]
        [HttpPost("auth")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Authentication([FromForm]AuthenticateModel model)
        {
            var user = await _userService.Get(model.Username, model.Password);
            user.Token = _authenticationService.GenerateToken(user);
            await _userService.UpdateUserToken(user.Id, user.Token);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Register([FromForm]AuthenticateModel model)
        {
            await _userService.RegisterUser(model.Username, model.Password);
            return await Authentication(model);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
    }
}