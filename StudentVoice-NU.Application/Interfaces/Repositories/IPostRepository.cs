
namespace StudentVoiceNU.Application.Interfaces.Repositories
{
    public interface IPostRepository  : IBaseRepository<Post> {
        Task<IEnumerable<Post>> GetPostsByUserId(int userId);
    }
}
