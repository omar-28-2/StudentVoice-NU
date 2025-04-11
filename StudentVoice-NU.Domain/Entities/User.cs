public class User : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int EnrollmentYear { get; set; }
    public UserRole Role { get; set; }
    public int MajorId { get; set; }
    public Major? Major { get; set; }
    public virtual List<Post>? Posts { get; set; }
    public virtual  List<Comment>? Comments { get; set; }
    public virtual List<Vote>? Votes { get; set; }
}
public enum UserRole
{
    Admin,
    Student,
    Alumni
}