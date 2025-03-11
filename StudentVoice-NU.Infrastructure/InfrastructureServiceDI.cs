using Microsoft.Extensions.DependencyInjection;
using StudentVoiceNU.Infrastructure.Services;

namespace StudentVoiceNU.Infrastructure
{
    public static class InfrastructureServiceDI
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<FileStorageService>();
            services.AddScoped<EmailService>();
            services.AddScoped<LoggingService>();
        }
    }
}
