using StudentVoiceNU.Domain.Entities;

public class Admin : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public RequestStatus Status { get; set; }
}

public enum RequestStatus
{
    Pending,
    Accepted,
    Rejected
}