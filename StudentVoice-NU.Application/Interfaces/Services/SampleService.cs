using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Application.Interfaces.Services;
using StudentVoiceNU.Domain.Entities;

namespace StudentVoiceNU.Application.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public async Task<IEnumerable<SampleEntity>> GetAllSamplesAsync()
        {
            return await _sampleRepository.GetAllAsync();
        }

        public async Task<SampleEntity> GetSampleByIdAsync(int id)
        {
            return await _sampleRepository.GetByIdAsync(id);
        }

        public async Task<SampleEntity> AddSampleAsync(SampleEntity sample)
        {
            return await _sampleRepository.AddAsync(sample);
        }

        public async Task DeleteSampleAsync(int id)
        {
            var sample = await _sampleRepository.GetByIdAsync(id);
            if (sample != null)
            {
                await _sampleRepository.DeleteAsync(sample);
            }
        }
    }
}
