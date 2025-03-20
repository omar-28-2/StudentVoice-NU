using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Domain.DTOs;
using StudentVoiceNU.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace StudentVoiceNU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public abstract class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok("The project is running!");
        }
    }
}
