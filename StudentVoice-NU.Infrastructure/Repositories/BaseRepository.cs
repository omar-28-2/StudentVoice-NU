using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Domain.Entities;
using StudentVoiceNU.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace StudentVoiceNU.Infrastructure.Repositories
{
    public class BaseRepository<T>(StudentVoiceDbContext context) : IBaseRepository<T> where T : BaseEntity
    {
        private readonly StudentVoiceDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly DbSet<T> _table = context.Set<T>();

        public async Task<T> Create(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var  entity = await _table.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            _table.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetbyId(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }

}
