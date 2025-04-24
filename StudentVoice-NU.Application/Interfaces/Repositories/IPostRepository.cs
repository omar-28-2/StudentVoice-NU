
namespace StudentVoiceNU.Application.Interfaces.Repositories
{
    public interface IPostRepository  : IBaseRepository<Post> {
        Task<IEnumerable<Post>> GetPostsByUserId(int userId, int postNumber, int postSize );
        Task<Post?> GetbyId(int id);
        
    }
}
