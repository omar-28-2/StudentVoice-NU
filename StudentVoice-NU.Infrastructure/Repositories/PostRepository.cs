using Microsoft.EntityFrameworkCore;
using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Domain.Entities;
using StudentVoiceNU.Infrastructure.Contexts;

namespace StudentVoiceNU.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository 
    {
        private readonly StudentVoiceDbContext _context;

        public PostRepository(StudentVoiceDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetPostsByUserId(int userId)
        {
            return await _context.Posts
                .Where(p => p.UserId == userId)
                .Include(p => p.Comments) 
                .Include(p => p.Votes)    
                .ToListAsync();
        }
    }
}