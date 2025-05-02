using Microsoft.EntityFrameworkCore;
using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Domain.DTOs;
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
    public async Task<ReadPostDto?> GetPostbyId(int id,int commentsPageNumber = 1, int commentsPageSize = 10, int votesPageNumber = 1, int votesPageSize = 10)
    {
    return await _context.Posts
        .Where(p => p.UserId == id)
        .Select(p => new ReadPostDto
        {
            Id = p.Id,
            Content = p.Content,
            CreatedAt = p.CreatedAt,
        })
        .FirstOrDefaultAsync();
        }
    public async Task <IEnumerable<Comment>> GetCommentsByPostId(int postId,int pageNumber = 1, int pageSize = 10)
    {
        return await _context.Comments
        .Where(c => c.PostId == postId)
        .OrderBy(c => c.CreatedAt)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
    }
    public async Task<IEnumerable<Vote>> GetVotesByPostId(int postId,int pageNumber = 1, int pageSize = 10)
    {
        return await _context.Votes
        .Where(v => v.PostId == postId)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
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