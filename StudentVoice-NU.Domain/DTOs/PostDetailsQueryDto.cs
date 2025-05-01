namespace StudentVoiceNU.Domain.DTOs
{
    public class PostDetailsQueryDto
    {
        public int CommentsPageNumber { get; set; } = 1;
        public int CommentsPageSize { get; set; } = 10;
        public int VotesPageNumber { get; set; } = 1;
        public int VotesPageSize { get; set; } = 10;
    }
}
