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
        public async Task<Post?> GetById(int id) 
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.Votes)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Post>> GetPostsByUserId(int userId,int postNumber=1,int postSize=10)
        {
            return await _context.Posts
                .Where(p => p.UserId == userId)
                .Include(p => p.Comments) 
                .Include(p => p.Votes)    
                .OrderByDescending(p => p.CreatedAt)
                .Skip((postNumber - 1) * postSize)
                .Take(postSize)
                .ToListAsync();
        }
    }
}