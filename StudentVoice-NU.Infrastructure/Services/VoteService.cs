using StudentVoiceNU.Domain.DTOs;
using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Application.Services;

namespace StudentVoiceNU.Infrastructure.Services
{
public class VoteService : IVoteService
{
    private readonly IVoteRepository _voteRepository;

    public VoteService(IVoteRepository voteRepository)
    {
        _voteRepository = voteRepository;
    }

    public async Task<bool> Upvote(CreateVoteDto dto)
    {
        var vote = await _voteRepository.GetUserVoteOnPost(dto.UserId, dto.PostId);
        if (vote != null)
        {
            vote.IsUpvote = true;
            return await _voteRepository.Update(vote) != null;
        }

        return await _voteRepository.Create(new Vote
        {
            UserId = dto.UserId,
            PostId = dto.PostId,
            IsUpvote = true,
            CreatedAt = DateTime.UtcNow
        }) != null;
    }

    public async Task<bool> Downvote(CreateVoteDto dto)
    {
        var vote = await _voteRepository.GetUserVoteOnPost(dto.UserId, dto.PostId);
        if (vote != null)
        {
            vote.IsUpvote = false;
            return await _voteRepository.Update(vote) != null;
        }

        return await _voteRepository.Create(new Vote
        {
            UserId = dto.UserId,
            PostId = dto.PostId,
            IsUpvote = false,
            CreatedAt = DateTime.UtcNow
        }) != null;
    }

    public async Task<bool> RemoveVote(CreateVoteDto dto)
    {
        return await _voteRepository.DeleteByUserAndPost(dto.UserId, dto.PostId);
    }
}
}