using Microsoft.AspNetCore.Mvc;
using StudentVoiceNU.Application.Interfaces.Services;
using StudentVoiceNU.Domain.Entities;

namespace StudentVoiceNU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSamples()
        {
            var samples = await _sampleService.GetAllSamplesAsync();
            return Ok(samples);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSample(int id)
        {
            var sample = await _sampleService.GetSampleByIdAsync(id);
            if (sample == null) return NotFound();
            return Ok(sample);
        }

        [HttpPost]
        public async Task<IActionResult> AddSample([FromBody] SampleEntity sample)
        {
            var createdSample = await _sampleService.AddSampleAsync(sample);
            return CreatedAtAction(nameof(GetSample), new { id = createdSample.Id }, createdSample);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSample(int id)
        {
            await _sampleService.DeleteSampleAsync(id);
            return NoContent();
        }
    }
}
