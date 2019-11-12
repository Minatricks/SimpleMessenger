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
        public IActionResult Authentication(AuthenticateModel model)
        {
            var user = _userService.Get(model.Username, model.Password);
            user.Token = _authenticationService.GenerateToken(user);
            return Ok(user); 
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthenticateModel model)
        {
            var isOk = await _userService.RegisterUser(model.Username, model.Password);
            return Ok(Convert.ToBoolean(isOk));
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
    }
}