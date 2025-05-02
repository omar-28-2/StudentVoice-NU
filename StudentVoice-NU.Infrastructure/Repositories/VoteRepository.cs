using Microsoft.EntityFrameworkCore;
using StudentVoiceNU.Infrastructure.Contexts;
using StudentVoiceNU.Infrastructure.Repositories;

public class VoteRepository : BaseRepository<Vote>, IVoteRepository
{
    private readonly StudentVoiceDbContext _context;

    public VoteRepository(StudentVoiceDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Vote?> GetUserVoteOnPost(int userId, int postId)
    {
        return await _context.Votes
            .FirstOrDefaultAsync(v => v.UserId == userId && v.PostId == postId);
    }

    public async Task<bool> DeleteVote(int id)
{
    var vote = await _context.Votes.FindAsync(id);
    if (vote == null) return false;

    _context.Votes.Remove(vote);
    await _context.SaveChangesAsync();
    return true;
}


}
