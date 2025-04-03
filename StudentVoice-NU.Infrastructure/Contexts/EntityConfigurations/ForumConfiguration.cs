using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentVoiceNU.Domain.Entities;

namespace StudentVoiceNU.Infrastructure.Contexts.EntityConfigurations
{
    public class ForumConfiguration : IEntityTypeConfiguration<Forum>
    {
        public void Configure(EntityTypeBuilder<Forum> builder)
        {
            // Set primary key
            builder.HasKey(f => f.Id);

            // Configure properties
            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(f => f.Type)
                .IsRequired();

        }
    }
}
