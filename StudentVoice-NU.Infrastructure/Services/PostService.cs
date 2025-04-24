using StudentVoiceNU.Domain.DTOs;
using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Application.Services;

namespace StudentVoiceNU.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostDto>> GetPostsByUser(int userId, int pageNumber, int pageSize)
        {
            var posts = await _postRepository.GetPostsByUserId(userId, pageNumber, pageSize);
            return posts.Select(p => new PostDto
            {
                Id = p.Id,
                Content = p.Content,
                CreatedAt = p.CreatedAt
            });
        }

        public async Task<PostDto?> GetPostById(int id)
        {
            var post = await _postRepository.GetbyId(id);
            if (post == null) return null;

            return new PostDto
            {
                Id = post.Id,
                Content = post.Content,
                CreatedAt = post.CreatedAt
            };
        }

        public async Task<PostDto> CreatePost(CreatePostDto dto)
        {
            var post = new Post
            {
                Content = dto.Content,
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _postRepository.Create(post);
            return new PostDto
            {
                Id = created.Id,
                Content = created.Content,
                CreatedAt = created.CreatedAt
            };
        }

        public async Task<bool> UpdatePost(int id, CreatePostDto dto)
        {
            var post = await _postRepository.GetbyId(id);
            if (post == null) return false;

            post.Content = dto.Content;
            post.UserId = dto.UserId;

            await _postRepository.Update(post);
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            var deleted = await _postRepository.Delete(id);
            return deleted != null;
        }
    }
}
