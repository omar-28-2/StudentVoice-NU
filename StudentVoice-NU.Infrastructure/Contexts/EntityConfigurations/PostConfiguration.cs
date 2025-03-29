using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentVoiceNU.Domain.Entities;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.User)
               .WithMany(u => u.Posts)
               .HasForeignKey(p => p.UserId);
               
        
    }
}
