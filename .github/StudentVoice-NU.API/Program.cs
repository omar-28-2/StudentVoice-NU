using StudentVoiceNU.Application.Interfaces.Services;
using StudentVoiceNU.Application.Services;
using StudentVoiceNU.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Dependency Injection (DI)
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFirebaseAuthService, FirebaseAuthService>(); // ✅ FIXED: No duplicate registrations

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentVoiceNU API v1");
    });
}
app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();

app.Run();
