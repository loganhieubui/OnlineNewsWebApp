using OnlineNewsWebApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OnlineNewsWebApp.Infrastructure.Database
{
    public static class OnlineNewsSeed
    {
        public static void SeedData(this ModelBuilder builder)
        {
            List<Category> categories = new List<Category>();
            List<Post> posts = new List<Post>();
            List<Tag> tags = new List<Tag>();
            List<PostTagMap> postTags = new List<PostTagMap>();
            List<Comment> comments = new List<Comment>();

            
            //Roles
            var roles = new IdentityRole[]
            {
                // assume that 0 is writer, 1 is admin, 2 is reader
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                },                                
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
                },
            };
            
            //Users
            var users = new User[]
            {
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Age = LoremNET.RandomHelper.Instance.Next(20, 60),
                    AboutMe = LoremNET.Lorem.Words(10),
                    UserName = "loganhieubui",
                    NormalizedUserName = "loganhieubui".ToUpper(),
                    Email = "trunghieusuper@gmail.com",
                    NormalizedEmail = "trunghieusuper@gmail.com".ToUpper(),
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null!, "TrungHieu2112"),
                    FirstName = "Logan",
                    LastName = "HieuBui"
},
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Age = LoremNET.RandomHelper.Instance.Next(20, 60),
                    AboutMe =  LoremNET.Lorem.Words(10),
                    UserName = "jimmycarter",
                    NormalizedUserName = "jimmycarter".ToUpper(),
                    Email = "buitrunghieu_t65@hus.edu.vn",
                    NormalizedEmail = "buitrunghieu_t65@hus.edu.vn".ToUpper(),
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null!, "BuiTrungHieu2112"),
                    FirstName = "Jimmy",
                    LastName = "Carter"
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Age = LoremNET.RandomHelper.Instance.Next(20, 60),
                    AboutMe =  LoremNET.Lorem.Words(10),
                    UserName = "ricardo",
                    NormalizedUserName = "ricardo".ToUpper(),
                    Email = "buihieu.211202@gmail.com",
                    NormalizedEmail = "buihieu.211202@gmail.com".ToUpper(),
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null!, "BuiHieu2112"),
                    FirstName = "Ricardo",
                    LastName = "MyLord"
                },
            };

            //UserRoles
            var userRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    RoleId = roles[0].Id,
                    UserId = users[1].Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = roles[2].Id,
                    UserId = users[0].Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = roles[1].Id,
                    UserId = users[2].Id
                }
            };

            // Categories
            for (int i = 1; i <= 10; i++)
            {
                categories.Add(new Category
                {
                    Id = i,
                    Name = LoremNET.Lorem.Words(2),
                    Description = LoremNET.Lorem.Words(12)
                });
            }

            // Posts
            
            for (int i = 1; i <= 50; i++)
            {
                posts.Add(new Post
                {
                    Id = i,
                    Title = LoremNET.Lorem.Words(3),
                    UrlSlug = LoremNET.Lorem.Words(3).ToLower().Replace(' ', '-'),
                    ShortDescription = LoremNET.Lorem.Words(13),
                    PostContent = LoremNET.Lorem.Paragraph(10, 20, 4, 8),
                    PostedOn = LoremNET.Lorem.DateTime(DateTime.Now.AddDays(-10), DateTime.Now),
                    Published = true,
                    CategoryId = LoremNET.RandomHelper.Instance.Next(1, 10),
                    RateCount = LoremNET.RandomHelper.Instance.Next(10, 30),
                    TotalRate = LoremNET.RandomHelper.Instance.Next(100, 300),
                    ViewCount = LoremNET.RandomHelper.Instance.Next(100, 300),
                    AuthorId = users[LoremNET.RandomHelper.Instance.Next(0, 2)].Id

                });
            }

            // Tags
            for (int i = 1; i <= 20; i++)
            {
                tags.Add(new Tag
                {
                    Id = i,
                    Name = LoremNET.Lorem.Words(3),
                    Count = 0
                });
            }

            // PostTags
            for (int i = 1; i <= 30; i++)
            {
                int j = LoremNET.RandomHelper.Instance.Next(0, 20);
                postTags.Add(new PostTagMap
                {
                    PostId = posts[LoremNET.RandomHelper.Instance.Next(0, 50)].Id,
                    TagId = tags[j].Id
                });
                tags[j].Count += 1;
            }

            // update count posts attribute of tags
            

            // Comments
            for (int i = 1; i <= 20; i++)
            {
                comments.Add(new Comment
                {
                    Id = i,
                    CommentHeader = LoremNET.Lorem.Words(3),
                    CommentText = LoremNET.Lorem.Paragraph(10, 20, 1, 3),
                    CommentTime = LoremNET.Lorem.DateTime(DateTime.Now.AddDays(-10), DateTime.Now),
                    Email = LoremNET.Lorem.Email(),
                    Name = LoremNET.Lorem.Words(2),
                    PostId = LoremNET.RandomHelper.Instance.Next(0, 50)
                });
            }

            //Seed data
            builder.Entity<User>().HasData(users);
            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            builder.Entity<Category>().HasData(categories);
            builder.Entity<Post>().HasData(posts);
            builder.Entity<Tag>().HasData(tags);
            builder.Entity<PostTagMap>().HasData(postTags);
            builder.Entity<Comment>().HasData(comments);
            
        }
    }
}