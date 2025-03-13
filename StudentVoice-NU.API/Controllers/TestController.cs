using Microsoft.AspNetCore.Mvc;
using StudentVoiceNU.Application.Interfaces.Services;

namespace StudentVoiceNU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Generalized Route
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService) // Inject the service
        {
            _testService = testService;
        }

        [HttpGet]
        public IActionResult GetTestMessage()
        {
            var message = _testService.GetMessage();
            return Ok(new { message });
        }
    }
}
