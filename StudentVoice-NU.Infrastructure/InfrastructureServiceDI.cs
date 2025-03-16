using Microsoft.Extensions.DependencyInjection;
using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Infrastructure.Repositories;
using StudentVoiceNU.Infrastructure.Repositories.Common;
using StudentVoiceNU.Application.Interfaces.Services;
using StudentVoiceNU.Infrastructure.Services;

namespace StudentVoiceNU.Infrastructure
{
    public static class InfrastructureServiceDI
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
