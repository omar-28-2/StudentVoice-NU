using StudentVoiceNU.Application.Interfaces.Repositories; // Ensure the correct namespace for IBaseRepository
public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<Comment?> GetById(int id);
    Task<IEnumerable<Comment>> GetCommentsByPost(int postId, int page, int pageSize);
}
