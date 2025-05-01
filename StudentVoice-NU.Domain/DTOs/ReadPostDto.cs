namespace StudentVoiceNU.Domain.DTOs
{
    public class ReadPostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CommentsCount { get; set; } 
        public int VotesCount { get; set; } 
        public IEnumerable<Comment>? Comments { get; set; } = new List<Comment>();
        public IEnumerable<Vote>? Votes { get; set; } = new List<Vote>();
    }   
}
