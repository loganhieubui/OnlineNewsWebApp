using OnlineNewsWebApp.Infrastructure.IRepos;
using OnlineNewsWebApp.Core.Entities;
using OnlineNewsWebApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace OnlineNewsWebApp.Infrastructure.Repos
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(OnlineNewsContext context) : base(context) { }

        // using ! allow null reference "null-forgiving operator"

        public IList<Post> GetLatestPost(int size)
        {
            return Context.Posts!.Include(p => p.Category).Include(p => p.Author).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }
        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return Context.Posts!.Where(p => p.PostedOn.Month == monthYear.Month).ToList();
        }
        public IList<Post> GetPostsByCategory(string category)
        {
            // apply eager loading to load category and tags of the posts using .Include()
            return Context.Posts!.Where(p => p.Category!.Name == category).Include(p => p.Category).Include(p => p.Author).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).ToList();
        }
        public IList<Post> GetPostsByTag(string tag)
        {
            return Context.Tags!.Where(t => t.Name == tag).SelectMany(t => t.PostTagMaps.Select(ptm => ptm.Post)).Include(p => p.Category).Include(p => p.Author).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).ToList();
        }

        public IList<Post> GetMostViewedPosts(int size)
        {
            return Context.Posts!.Include(p => p.Category).Include(p => p.Author).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }
        public IList<Post> GetHighestPosts(int size)
        {
            return Context.Posts!.Include(p => p.Category).Include(p => p.Author).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).AsEnumerable().OrderByDescending(p => p.Rate).Take(size).ToList();
        }
        public IList<Post> GetAllPostsWithCategoryAndTags()
        {
            return Context.Posts!.Include(p => p.Category).Include(p => p.Author).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).ToList();
        }

        public void AddTags(int postId, IList<int> tagIds)
        {
            var postTagMaps = tagIds.Select(tagId => new PostTagMap
            {
                PostId = postId,
                TagId = tagId
            });
            Context.PostTagMaps!.AddRange(postTagMaps);
        }

        public void DeleteTags(int postId)
        {
            Context.PostTagMaps!.RemoveRange(Context.PostTagMaps.Where(ptm => ptm.PostId == postId));
        }
        public Post GetPostWithTags(int id)
        {
            return Context.Posts!.Include(p => p.PostTagMaps).First(p => p.Id == id);
        }
        public Post GetDetails(int year, int month, string urlSlug)
        {
            return Context.Posts!.Include(p => p.Category).Include(p => p.Author).Include(p => p.Author).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).Include(p => p.Comments).First(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == urlSlug);
        }

        public IList<Post> GetPostsByTitle(string title)
        {
            return Context.Posts!.Where(p => p.Title.Contains(title)).Include(p => p.Category).Include(p => p.Author).Include(p => p.Author).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).Include(p => p.Comments).ToList();
        }
    }
}
