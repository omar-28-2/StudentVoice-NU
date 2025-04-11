using StudentVoiceNU.Domain.Entities;

public class Event : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ClubId { get; set; }
    public virtual Club? Club { get; set; }
}