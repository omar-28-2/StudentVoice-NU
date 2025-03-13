using Microsoft.Extensions.DependencyInjection;
using StudentVoiceNU.Application.Interfaces.Services;
using StudentVoiceNU.Application.Services;

namespace StudentVoiceNU.Application
{
    public static class ApplicationServiceDI
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ISampleService, SampleService>();
        }
    }
}
