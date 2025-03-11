using StudentVoiceNU.Application.Interfaces;

namespace StudentVoiceNU.Application.Interfaces.Services
{
    public class TestService : IBaseService<string>
    {
        public string GetMessage() => "Hello from Clean Architecture!";
    }
}
