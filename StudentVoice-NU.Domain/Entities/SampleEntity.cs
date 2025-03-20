namespace StudentVoiceNU.Domain.Entities
{
    public abstract class SampleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }
    }
}
