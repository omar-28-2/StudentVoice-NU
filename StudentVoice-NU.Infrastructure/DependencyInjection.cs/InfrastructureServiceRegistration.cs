using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Infrastructure.Repositories;
using StudentVoiceNU.Infrastructure.Contexts;

namespace StudentVoiceNU.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<StudentVoiceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
