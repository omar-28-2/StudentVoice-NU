using StudentVoiceNU.Domain.DTOs;

namespace StudentVoiceNU.Application.Services
{
    public interface IVoteService
{
    Task<bool> Upvote(CreateVoteDto dto);
    Task<bool> Downvote(CreateVoteDto dto);
    Task<bool> RemoveVote(CreateVoteDto dto);
}

}

