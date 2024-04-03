using OnlineNewsWebApp.Core.Entities;

namespace OnlineNewsWebApp.Infrastructure.IRepos
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        /// <summary>
        /// Get top tags for sidebar of post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Tag> GetTopTags(int size);
    }
}
