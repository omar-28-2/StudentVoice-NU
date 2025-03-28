using Microsoft.EntityFrameworkCore;
using StudentVoiceNU.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using StudentVoiceNU.Infrastructure.Contexts;

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

      
    
    }
}
