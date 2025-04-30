using StudentVoiceNU.Domain.DTOs;

namespace StudentVoiceNU.Application.Services
{
    public interface ICommentService
    {
        Task<ReadCommentDto> AddComment(CreateCommentDto dto);
        Task<bool> UpdateComment(int id, UpdateCommentDto dto);
        Task<bool> DeleteComment(int id);
        Task<ReadCommentDto?> GetCommentById(int id);

        Task<IEnumerable<ReadCommentDto>> GetCommentsByPost(int postId, int page, int pageSize);
    }
}


