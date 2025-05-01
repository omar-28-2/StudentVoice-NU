using StudentVoiceNU.Application.Interfaces.Repositories;

public interface IVoteRepository : IBaseRepository<Vote>
{
    Task<Vote?> GetUserVoteOnPost(int userId, int postId);
    Task<bool> DeleteVote(int id);

}
