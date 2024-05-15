using Microsoft.EntityFrameworkCore;
using OnlineNewsWebApp.Core.Configs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineNewsWebApp.Core.Entities;

namespace OnlineNewsWebApp.Infrastructure.Database
{
    public sealed class OnlineNewsContext : IdentityDbContext<User>
    {
        
        public OnlineNewsContext() { }
        public OnlineNewsContext(DbContextOptions<OnlineNewsContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);            
            optionsBuilder.EnableSensitiveDataLogging().UseSqlServer("Server=LAPTOP-A9P1I74O;Database=OnlineNews;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");
            // log the SQL and change tracking information for debugging purposes 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // shorten the aspnet table names
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName!.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new PostConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());
            modelBuilder.ApplyConfiguration(new PostTagMapConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());

            modelBuilder.SeedData2();
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<PostTagMap>? PostTagMaps { get; set; }
        public DbSet<Comment>? Comments { get; set; }
    }
}