using StudentVoiceNU.Domain.DTOs;
using StudentVoiceNU.Application.Services;
namespace StudentVoiceNU.Infrastructure.Services;
using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Domain.Entities;
public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<ReadCommentDto> AddComment(CreateCommentDto dto)
    {
        var comment = new Comment
        {
            Content = dto.Content,
            UserId = dto.UserId,
            PostId = dto.PostId,
            CreatedAt = DateTime.UtcNow
        };

        var created = await _commentRepository.Create(comment);
        return new ReadCommentDto
        {
            Id = created.Id,
            Content = created.Content,
            CreatedAt = created.CreatedAt,
            UserId = created.UserId,
            PostId = created.PostId
        };
    }

    public async Task<ReadCommentDto?> GetCommentById(int id)
    {
        var comment = await _commentRepository.GetById(id);
        if (comment == null) return null;

        return new ReadCommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            UserId = comment.UserId,
            PostId = comment.PostId
        };
    }

    public async Task<IEnumerable<ReadCommentDto>> GetCommentsByPost(int postId, int page, int pageSize)
        {
            var allComments = await _commentRepository.GetCommentsByPostId(postId);
            var paginated = allComments
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new ReadCommentDto
                {
                    Id = c.Id,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    UserId = c.UserId,
                    PostId = c.PostId
                });

            return paginated;
        }

    

    public async Task<bool> UpdateComment(int id, UpdateCommentDto dto)
    {
        var comment = await _commentRepository.GetById(id);
        if (comment == null) return false;

        comment.Content = dto.Content;
        await _commentRepository.Update(comment);
        return true;
    }

    public async Task<bool> DeleteComment(int id)
    {
        var deleted = await _commentRepository.Delete(id);
        return deleted != null;
    }
}
