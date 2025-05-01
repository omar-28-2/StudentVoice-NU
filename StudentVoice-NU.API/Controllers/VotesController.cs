using Microsoft.AspNetCore.Mvc;
using StudentVoiceNU.Domain.DTOs;
using StudentVoiceNU.Application.Services;

namespace StudentVoiceNU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VotesController(IVoteService voteService)
        {
            _voteService = voteService ?? throw new ArgumentNullException(nameof(voteService));
        }

        [HttpPost]
        public async Task<IActionResult> CreateVote([FromBody] CreateVoteDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.VoteType))
                return BadRequest("Invalid vote data.");

            var result = dto.VoteType.ToLower() switch
            {
                "upvote" => await _voteService.Upvote(dto),
                "downvote" => await _voteService.Downvote(dto),
                _ => false
            };

            if (!result) return BadRequest("Failed to register vote.");
            return Ok("Vote registered.");
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
