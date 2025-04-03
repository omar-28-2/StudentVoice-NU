public class Post : AuditableEntity
{
    public string Content { get; set; }
    public bool IsAnonymous { get; set; }
    public int UserId { get; set; }
    public int ForumId { get; set; }
    public Forum? Forum { get; set; }
    public virtual IList<Comment>? Comments { get; set; } = new List<Comment>();
    public virtual List<Vote>? Votes{ get; set; } = new();
    public User? User { get; set; }
}