using Microsoft.EntityFrameworkCore;
using StudentVoiceNU.Infrastructure.Contexts;
using StudentVoiceNU.Infrastructure.Repositories;

public class CommentRepository : BaseRepository<Comment> , ICommentRepository
{
    private readonly StudentVoiceDbContext _context;

    public CommentRepository(StudentVoiceDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Comment?> GetById(int id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPost(int postId, int page, int pageSize)
    {
        return await _context.Comments
            .Where(c => c.PostId == postId)
            .OrderByDescending(c => c.CreatedAt)
            .Skip((page - 1) * pageSize)  
            .Take(pageSize)  
            .ToListAsync();
    }
}

