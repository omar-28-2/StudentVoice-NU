using StudentVoiceNU.Domain.Entities;
public class CommentLike : BaseEntity
{
    public int CommentId { get; set; }
    public int UserId { get; set; }
    public Comment Comment { get; set; }
    public User User { get; set; }
}