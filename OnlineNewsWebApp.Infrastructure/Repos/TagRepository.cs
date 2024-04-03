using OnlineNewsWebApp.Infrastructure.IRepos;
using OnlineNewsWebApp.Infrastructure.Database;
using OnlineNewsWebApp.Core.Entities;

namespace OnlineNewsWebApp.Infrastructure.Repos
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(OnlineNewsContext context) : base(context) { }

        public IList<Tag> GetTopTags(int size)
        {
            return Context.Tags!.OrderByDescending(t => t.PostTagMaps.Count).Take(size).ToList();
        }
    }
}
