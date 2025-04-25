
using StudentVoiceNU.Domain.DTOs;

namespace StudentVoiceNU.Application.Interfaces.Repositories
{
    public interface IPostRepository  : IBaseRepository<Post> {
        Task<IEnumerable<Post>> GetPostsByUserId(int userId, int pageNumber, int pageSize );
        Task<ReadPostDto?> GetPostbyId(int id, int commentsPageNumber = 1, int commentsPageSize = 10, int votesPageNumber = 1, int votesPageSize = 10);
        Task<IEnumerable<Comment>> GetCommentsByPostId(int postId, int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<Vote>> GetVotesByPostId(int postId, int pageNumber = 1, int pageSize = 10);
        Task<int> GetCommentsCountByPostId(int postId);
        Task<int> GetVotesCountByPostId(int postId);
    }
}
