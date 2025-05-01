namespace StudentVoiceNU.Domain.DTOs
{
public class CreateVoteDto
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string VoteType { get; set; }
}
}