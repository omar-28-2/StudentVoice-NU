using System;
using System.Threading.Tasks;
using StudentVoiceNU.Application.Interfaces.Services;

namespace StudentVoiceNU.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailAsync(string to, string subject, string body)
        {
            // Simulate sending email (Replace with real SMTP logic)
            await Task.Delay(500);
            Console.WriteLine($"Email sent to {to} with subject: {subject}");
            return true;
        }
    }
}
