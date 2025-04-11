using StudentVoiceNU.Domain.Entities;
public class CommentLike : BaseEntity
{
    public int CommentId { get; set; }
    public int UserId { get; set; }
    public virtual Comment? Comment { get; set; }
    public virtual User? User { get; set; }
}