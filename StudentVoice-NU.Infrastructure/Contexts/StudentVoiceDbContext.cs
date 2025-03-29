using Microsoft.EntityFrameworkCore;
using StudentVoiceNU.Domain.Entities;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using StudentVoiceNU.Infrastructure.Contexts;
using StudentVoiceNU.Infrastructure.Contexts.EntityConfigurations; 

namespace StudentVoiceNU.Infrastructure.Contexts
{
    public class StudentVoiceDbContext : DbContext
    {
        public StudentVoiceDbContext(DbContextOptions<StudentVoiceDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Event> Events { get; set; }   
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<Admin> Admins { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
//                 optionsBuilder.UseSqlServer("Server=DESKTOP-91S1SOI;Database=StudentVoice;Trusted_Connection=True;TrustServerCertificate=True;");
//         }
// }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Apply configurations
    modelBuilder.ApplyConfiguration(new UserConfiguration());
    modelBuilder.ApplyConfiguration(new PostConfiguration());
    modelBuilder.ApplyConfiguration(new CommentConfiguration());
    modelBuilder.ApplyConfiguration(new ForumConfiguration());
    modelBuilder.ApplyConfiguration(new VoteConfiguration());
}
    }
}
