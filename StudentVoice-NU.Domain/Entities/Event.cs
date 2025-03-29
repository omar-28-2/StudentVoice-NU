using StudentVoiceNU.Domain.Entities;

public class Event : BaseEntity
{
    public int ClubId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Club Club { get; set; }
}