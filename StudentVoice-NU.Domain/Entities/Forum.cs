public class Forum : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsAnonymous { get; set; }
    public ForumType Type { get; set; }
    public virtual List<Post>? Posts { get; set; }=new();
}
public enum ForumType
{
    General,
    Club,
    Event,
    Course
}