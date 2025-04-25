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
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }

        public async Task<IEnumerable<ReadPostDto>> GetPostsByUser(int userId, int pageNumber, int pageSize)
        {
            var posts = await _postRepository.GetPostsByUserId(userId, pageNumber, pageSize);
            return posts.Select(p => new ReadPostDto
            {
                Id = p.Id,
                Content = p.Content,
                CreatedAt = p.CreatedAt
            });
        }

        public async Task<ReadPostDto?> GetPostById(int id,int commentsPageNumber = 1, int commentsPageSize = 10, int votesPageNumber = 1, int votesPageSize = 10)
        {
            var post = await _postRepository.GetPostbyId(id);
            if (post == null) return null;

            var commentsCount = await _postRepository.GetCommentsCountByPostId(id);
            var votesCount = await _postRepository.GetVotesCountByPostId(id);

            var comments = await _postRepository.GetCommentsByPostId(id, commentsPageNumber, commentsPageSize);
            var votes = await _postRepository.GetVotesByPostId(id, votesPageNumber, votesPageSize);

        return new ReadPostDto
        {
            Id = post.Id,
            Content = post.Content,
            CreatedAt = post.CreatedAt,
            CommentsCount = commentsCount,  
            VotesCount = votesCount,        
            Comments = comments,            
            Votes = votes                   
        };
        }
        public async Task<ReadPostDto> CreatePost(CreatePostDto dto)
        {
            var post = new Post
            {
                Content = dto.Content,
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _postRepository.Create(post);
            return new ReadPostDto
            {
                Id = created.Id,
                Content = created.Content,
                CreatedAt = created.CreatedAt
            };
        }

        public async Task<bool> UpdatePost(int id, ReadPostDto dto)
        {
            var post = await _postRepository.GetbyId(id);
            if (post == null) return false;

            post.Content = dto.Content;
            post.UserId = dto.Id;

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
