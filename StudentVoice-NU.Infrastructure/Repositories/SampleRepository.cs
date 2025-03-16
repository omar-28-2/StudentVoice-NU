using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Domain.Entities;
using StudentVoiceNU.Infrastructure.Contexts;
using StudentVoiceNU.Infrastructure.Repositories.Common;

namespace StudentVoiceNU.Infrastructure.Repositories
{
    public class SampleRepository : BaseRepository<SampleEntity>, ISampleRepository
    {
        public SampleRepository(StudentVoiceDbContext context) : base(context) { }
    }
}
