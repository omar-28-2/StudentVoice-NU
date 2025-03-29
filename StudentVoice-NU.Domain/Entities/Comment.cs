public class Comment : AuditableEntity
{
    public string Content { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public Post Post { get; set; }
    public User User { get; set; }
    public List<CommentLike>CommentLikes{ get; set; }=new();
}