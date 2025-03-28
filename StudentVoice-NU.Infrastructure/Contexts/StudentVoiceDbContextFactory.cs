using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace StudentVoiceNU.Infrastructure.Contexts
{
    public class StudentVoiceDbContextFactory : IDesignTimeDbContextFactory<StudentVoiceDbContext>
    {
        public StudentVoiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentVoiceDbContext>();

            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "StudentVoice-NU.API")) // Use relative path
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new StudentVoiceDbContext(optionsBuilder.Options);
        }
    }
}