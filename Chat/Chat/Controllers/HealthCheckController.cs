using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [Route("/hc")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Health check - ok");
        }
    }
}