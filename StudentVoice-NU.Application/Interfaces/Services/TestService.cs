using StudentVoiceNU.Application.Interfaces.Services;

namespace StudentVoiceNU.Application.Services
{
    public class TestService : ITestService
    {
        public string GetMessage()
        {
            return "Hello from TestService!";
        }
    }
}
