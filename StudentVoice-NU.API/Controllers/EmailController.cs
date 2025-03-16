using Microsoft.AspNetCore.Mvc;
using StudentVoiceNU.Application.Interfaces.Services;

namespace StudentVoiceNU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromQuery] string to, [FromQuery] string subject, [FromQuery] string body)
        {
            var success = await _emailService.SendEmailAsync(to, subject, body);
            return success ? Ok("Email sent successfully") : StatusCode(500, "Email sending failed");
        }
    }
}
