using Microsoft.EntityFrameworkCore;
using StudentVoiceNU.Domain.Entities;

namespace StudentVoiceNU.Infrastructure.Contexts
{
    public class StudentVoiceDbContext : DbContext
    {
        public StudentVoiceDbContext(DbContextOptions<StudentVoiceDbContext> options) : base(options)
        {
            
        }
        public DbSet<BaseEntity> BaseEntities { get; set; } 
    }
}
