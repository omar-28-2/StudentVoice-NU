public class User : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Major { get; set; }
    public int EnrollmentYear { get; set; }
    public UserRole Role { get; set; }
    public List<Post> Posts { get; set; }

    public List<Comment> Comments { get; set; }
    public List<Vote> Votes { get; set; }
}
public enum UserRole
{
    Admin,
    Student,
    Alumni
}