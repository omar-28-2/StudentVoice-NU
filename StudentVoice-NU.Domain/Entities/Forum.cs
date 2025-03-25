public class Forum : AuditableEntity
{
    public string   Name { get; set; }
    public int ForumID { get; set; }
    
    public string Description { get; set; }
    public bool IsAnonymous { get; set; }
    public string Type { get; set; }
    public List<Post> Posts { get; set; }=new();
}