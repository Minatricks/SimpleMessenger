using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Db;
using Chat.Db.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Chat.Controllers
{
    [Route("/user")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IChatDbContext _chatDbContext;


        public WeatherForecastController(IChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            int result;
            _chatDbContext.Users.Add(new Users() { Id = 1, Username = "First User" });
            result = await _chatDbContext.SaveChangesAsync();
            return Ok(result);
        }
    }
}
