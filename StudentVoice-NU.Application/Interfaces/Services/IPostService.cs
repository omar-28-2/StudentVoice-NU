using StudentVoiceNU.Domain.DTOs;

namespace StudentVoiceNU.Application.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetPostsByUser(int userId, int pageNumber, int pageSize);
        Task<PostDto?> GetPostById(int id);
        Task<PostDto> CreatePost(CreatePostDto dto);
        Task<bool> UpdatePost(int id, CreatePostDto dto);
        Task<bool> DeletePost(int id);
    }
}
