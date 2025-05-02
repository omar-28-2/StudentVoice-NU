using StudentVoiceNU.Application.Interfaces.Repositories; 
public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<Comment?> GetById(int id);
    Task<IEnumerable<Comment>> GetCommentsByPost(int postId, int page, int pageSize);
}
