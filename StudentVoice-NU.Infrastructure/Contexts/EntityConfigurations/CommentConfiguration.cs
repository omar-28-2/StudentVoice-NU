using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentVoiceNU.Domain.Entities;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);

        // Configure Comment -> User relationship
        builder.HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete

        // Configure Comment -> Post relationship
        builder.HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
               .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete
    }
}