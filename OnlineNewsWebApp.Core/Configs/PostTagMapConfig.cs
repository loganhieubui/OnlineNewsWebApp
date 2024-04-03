using OnlineNewsWebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineNewsWebApp.Core.Configs
{
    public class PostTagMapConfig : IEntityTypeConfiguration<PostTagMap>
    {
        public void Configure(EntityTypeBuilder<PostTagMap> builder)
        {
            builder.ToTable("PostTagMaps");
            // set composite key
            builder.HasKey(ptm => new { ptm.PostId, ptm.TagId });
            // set many-to-many relationship
            builder.HasOne(ptm => ptm.Post)
                .WithMany(p => p.PostTagMaps)
                .HasForeignKey(ptm => ptm.PostId);
            builder.HasOne(ptm => ptm.Tag)
                .WithMany(t => t.PostTagMaps)
                .HasForeignKey(ptm => ptm.TagId);
        }
    }
}
