namespace StudentVoiceNU.Domain.DTOs
{
public class ReadCommentDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
}
}