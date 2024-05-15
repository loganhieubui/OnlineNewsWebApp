using OnlineNewsWebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineNewsWebApp.Core.Configs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(256);
            builder.Property(p => p.ShortDescription).HasColumnName("Short Description").HasMaxLength(500);
            builder.Property(p => p.PostContent).HasColumnName("Post Content").IsRequired().HasMaxLength(10000);
            builder.Property(p => p.UrlSlug).HasMaxLength(256);
            builder.Property(p => p.Published).HasDefaultValue(false);
            builder.Property(p => p.PostedOn).HasColumnName("Posted On");
            builder.Property(p => p.Modified);
            builder.Property(p => p.ViewCount).HasColumnName("View Count").HasDefaultValue(0);
            builder.Property(p => p.RateCount).HasColumnName("Rate Count").HasDefaultValue(0);
            builder.Property(p => p.TotalRate).HasColumnName("Total Rate").HasDefaultValue(0);
            builder.Ignore(p => p.Rate);
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            // avoid delete all posts when delete a category by setting FK to null
            builder.HasOne(p => p.Author)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            // remeain posts when a writer is deleted
        }
    }
}
