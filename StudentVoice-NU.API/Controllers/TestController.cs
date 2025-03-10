using Microsoft.AspNetCore.Mvc;

namespace StudentVoiceNU.API.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            return Ok(new { message = "Hello from Clean Architecture!" });
        }
    }
}
