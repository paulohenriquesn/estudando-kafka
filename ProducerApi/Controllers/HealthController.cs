using Microsoft.AspNetCore.Mvc;

namespace ProducerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok("Hello World!");
        }
    }
}
