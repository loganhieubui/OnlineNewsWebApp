using OnlineNewsWebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineNewsWebApp.Core.Configs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(255);
            builder.Property(c => c.CommentHeader).HasMaxLength(255);
            builder.Property(c => c.CommentText).HasMaxLength(1026);
            builder.Property(c => c.CommentTime);
            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            // delete all comments attached to the post when delete that post
        }
    }
}
