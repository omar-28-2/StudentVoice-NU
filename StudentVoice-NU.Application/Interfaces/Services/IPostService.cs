using StudentVoiceNU.Domain.DTOs;

namespace StudentVoiceNU.Application.Services
{
    public interface IPostService
    {
        Task<IEnumerable<ReadPostDto>> GetPostsByUser(int userId, int pageNumber, int pageSize);
        Task<ReadPostDto?> GetPostById(int id, int commentsPageNumber, int commentsPageSize, int votesPageNumber, int votesPageSize);
        Task<ReadPostDto> CreatePost(CreatePostDto dto);
        Task<bool> UpdatePost(int id, ReadPostDto dto);
        Task<bool> DeletePost(int id);
    }
}
