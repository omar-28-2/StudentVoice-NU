using System.Linq.Expressions;
using StudentVoiceNU.Domain.Entities;
//using StudentVoiceNU.Domain.Interfaces.Repositories;  // ✅ Reference `IBaseRepository<>`



namespace StudentVoiceNU.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        // GET 
        Task<T> GetbyId(int id);

        // Create 
        Task<T> Create(T entity);

        // Update
        Task<T> Update(T entity);

        // Delete
        Task<T> Delete(int id);
    }
}
