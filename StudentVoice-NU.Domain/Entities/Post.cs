public class Post : AuditableEntity
{
    public string Content { get; set; }
    public bool IsAnonymous { get; set; }
    public int UserId { get; set; }
    public List<Comment> Comments { get; set; } = new();
    public List<Vote>Votes{ get; set; } = new();
     public User User { get; set; }
}