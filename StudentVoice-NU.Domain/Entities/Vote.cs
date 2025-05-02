using StudentVoiceNU.Domain.Entities;

public class Vote : BaseEntity
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public VoteType Type { get; set; }
    public Post Post { get; set; }
    public User User { get; set; }

         public bool IsUpvote { get; set; }         // Required
        public DateTime CreatedAt { get; set; }
}
public enum VoteType
{
    UpVote,
    DownVote
}