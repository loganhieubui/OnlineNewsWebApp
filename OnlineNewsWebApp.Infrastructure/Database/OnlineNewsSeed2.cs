using OnlineNewsWebApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;

namespace OnlineNewsWebApp.Infrastructure.Database
{

    public static class OnlineNewsSeed2
    {
        // parentLink có dạng "https://vietnamnet.vn"; cate có dạng "giao-duc" 
        public static List<string> GetChildLinks(string parentLink, string cate)
        {
            List<string> childLinks = new List<string>();

            // Tạo đối tượng HtmlWeb để tải và phân tích nội dung HTML của trang web
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDocument = htmlWeb.Load(parentLink + "/" + cate);

            // Sử dụng XPath để truy vấn các phần tử <a> chứa liên kết con
            HtmlNodeCollection linkNodes = htmlDocument.DocumentNode.SelectNodes("//a[@href]");
            if (linkNodes != null)
            {
                foreach (HtmlNode linkNode in linkNodes)
                {
                    string childLink = linkNode.GetAttributeValue("href", "");
                    if (childLink.EndsWith(".html") && childLink.Count(s => s == '/') == 1 && childLink.Count(char.IsDigit) <= 10)
                    {
                        childLink = parentLink + childLink;
                        childLinks.Add(childLink);
                    }
                }
            }

            return childLinks.Distinct().ToList();
        }

        // Truy cập vào url và lấy nội dung từ phần tử html có className
        public static string GetTextContentFromClass(string url, string className)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);
            HtmlNodeCollection nodes;

            // Lựa chọn tất cả các phần tử có lớp tương ứng
            if (className == "maincontent main-content")
            {
                nodes = document.DocumentNode.SelectNodes($"//div[contains(@class, '{className}')]//p");
            }
            else
            {
                nodes = document.DocumentNode.SelectNodes($"//*[contains(@class, '{className}')]");
            }


            if (nodes != null)
            {
                // Lấy văn bản từ các phần tử 
                string textContent = string.Join(" ", nodes.Select(node => node.InnerText).ToArray());
                return textContent;
            }


            return string.Empty;
        }

        public static DateTime CvtDateFromVNN(string datetime)
        {
            string[] tokens = datetime.Trim().Split(' ');
            string date = tokens[2];
            string format = "dd/MM/yyyy";
            DateTime dt = DateTime.ParseExact(date, format, null);
            return dt;
        }

        public static string GetHrefValues(string url, string data_index, string option)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);
            HtmlNode node = document.DocumentNode.SelectSingleNode(
                string.Format("//li[@data-i='{0}' and contains(@class, 'footer__top-items')]/a", data_index));
            if (node == null) return "";
            return node.GetAttributeValue(option, "").Replace("/", string.Empty);
        }
        public static void SeedData2(this ModelBuilder builder)
        {
            List<Category> categories = new List<Category>();
            List<Post> posts = new List<Post>();
            List<Tag> tags = new List<Tag>();
            List<PostTagMap> postTags = new List<PostTagMap>();
            List<Comment> comments = new List<Comment>();

            // link trang báo gốc crawl dữ liệu: báo Vietnamnet
            string newslink = "https://vietnamnet.vn";

            // chỉ số các categories sẽ lấy từ link trang báo gốc (lấy 22 categories)
            List<string> cate_index = new List<string>();
            for (int i = 1; i <= 25; i++)
            {
                if (i == 17 | i == 18 | i == 22) continue;
                cate_index.Add(i.ToString());
            }

            // tạo list tên các categories và tiêu đề categories lấy từ web
            List<string> cate_names = new List<string>();
            List<string> cate_titles = new List<string>();
            foreach(string s in cate_index)
            {
                cate_names.Add(GetHrefValues(newslink, s, "href"));
                cate_titles.Add(GetHrefValues(newslink, s, "title"));
            }

            


            //Roles
            var roles = new IdentityRole[]
            {
                // assume that 0 is writer, 1 is reader, 2 is admin
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
            for (int i = 1; i <= 22; i++)
            {
                categories.Add(new Category
                {
                    Id = i,
                    Name = cate_names[i - 1],
                    Description = cate_titles[i - 1]
                });
            }

            // Posts
            int np = 0; // number of posts
            for (int i = 1; i <= 22; i++)
            {
                // each category i has a different number of posts
                List<string> postlinks1cate = GetChildLinks(newslink, cate_names[i-1]);
                
                for(int j = 0; j < postlinks1cate.Count; j++)
                {
                    string l = postlinks1cate[j];
                    string dt = GetTextContentFromClass(l, "bread-crumb-detail__time");
                    DateTime dateTime = CvtDateFromVNN(dt);
                    posts.Add(new Post
                    {
                        Id = j+np+1,
                        Title = GetTextContentFromClass(l, "content-detail-title"),
                        UrlSlug = l.Substring(l.IndexOf(newslink) + 1 + newslink.Length),
                        ShortDescription = GetTextContentFromClass(l, "content-detail-sapo sm-sapo-mb-0"),                       
                        PostContent = GetTextContentFromClass(l, "maincontent main-content"),                        
                        PostedOn = dateTime,
                        //PostedOn = CvtDateFromVNN(GetTextContentFromClass(l, "bread-crumb-detail__time")),
                        Published = true,
                        // other properties are generated randomly
                        CategoryId = i,
                        RateCount = LoremNET.RandomHelper.Instance.Next(10, 30),
                        TotalRate = LoremNET.RandomHelper.Instance.Next(100, 300),
                        ViewCount = LoremNET.RandomHelper.Instance.Next(100, 300),
                        AuthorId = users[LoremNET.RandomHelper.Instance.Next(0, 2)].Id

                    });
                }
                np += postlinks1cate.Count;
                
            }

            // Tags
            for (int i = 1; i <= 50; i++)
            {
                tags.Add(new Tag
                {
                    Id = i,
                    Name = LoremNET.Lorem.Words(3),
                    Count = 0
                });
            }

            // PostTags
            // map each post with 3 different random tags 
            for (int i = 0; i < np; i++)
            {
                int j = LoremNET.RandomHelper.Instance.Next(0, 50);
                int k = LoremNET.RandomHelper.Instance.Next(0, 50);
                while (k == j) k = LoremNET.RandomHelper.Instance.Next(0, 50);
                int l = LoremNET.RandomHelper.Instance.Next(0, 50);
                while (l == j || l == k) l = LoremNET.RandomHelper.Instance.Next(0, 50); ;

                postTags.Add(new PostTagMap
                {
                    PostId = posts[i].Id,
                    TagId = tags[j].Id
                });
                postTags.Add(new PostTagMap
                {
                    PostId = posts[i].Id,
                    TagId = tags[k].Id
                });
                postTags.Add(new PostTagMap
                {
                    PostId = posts[i].Id,
                    TagId = tags[l].Id
                });
                // update count-posts attribute of each tags
                tags[j].Count += 1;
                tags[k].Count += 1;
                tags[l].Count += 1;
            }


            // Comments
            for (int i = 1; i <= 100; i++)
            {
                comments.Add(new Comment
                {
                    Id = i,
                    CommentHeader = LoremNET.Lorem.Words(3),
                    CommentText = LoremNET.Lorem.Paragraph(10, 20, 1, 3),
                    CommentTime = LoremNET.Lorem.DateTime(DateTime.Now.AddDays(-10), DateTime.Now),
                    Email = LoremNET.Lorem.Email(),
                    Name = LoremNET.Lorem.Words(2),
                    PostId = LoremNET.RandomHelper.Instance.Next(1, np+1)
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