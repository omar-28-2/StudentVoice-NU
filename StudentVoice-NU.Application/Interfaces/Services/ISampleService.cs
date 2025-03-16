using StudentVoiceNU.Domain.Entities;

namespace StudentVoiceNU.Application.Interfaces.Services
{
    public interface ISampleService
    {
        Task<IEnumerable<SampleEntity>> GetAllSamplesAsync();
        Task<SampleEntity> GetSampleByIdAsync(int id);
        Task<SampleEntity> AddSampleAsync(SampleEntity sample);
        Task DeleteSampleAsync(int id);
    }
}
