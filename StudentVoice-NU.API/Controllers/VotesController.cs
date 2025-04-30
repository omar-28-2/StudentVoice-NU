using Microsoft.AspNetCore.Mvc;
using StudentVoiceNU.Domain.DTOs; 
using StudentVoiceNU.Application.Services; // Replace with the actual namespace containing IVoteService
namespace StudentVoiceNU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VotesController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpPost("upvote")]
        public async Task<IActionResult> Upvote([FromBody] CreateVoteDto dto)
        {
            var success = await _voteService.Upvote(dto);
            if (!success) return BadRequest("Failed to upvote.");
            return Ok("Upvote registered.");
        }

        [HttpPost("downvote")]
        public async Task<IActionResult> Downvote([FromBody] CreateVoteDto dto)
        {
            var success = await _voteService.Downvote(dto);
            if (!success) return BadRequest("Failed to downvote.");
            return Ok("Downvote registered.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveVote([FromBody] CreateVoteDto dto)
        {
            var success = await _voteService.RemoveVote(dto);
            if (!success) return NotFound("Vote not found.");
            return NoContent();
        }
    }
}
