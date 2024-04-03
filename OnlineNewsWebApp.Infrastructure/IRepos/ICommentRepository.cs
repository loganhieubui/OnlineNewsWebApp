using OnlineNewsWebApp.Core.Entities;

namespace OnlineNewsWebApp.Infrastructure.IRepos
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        /// <summary>
        /// Get comments of post with postId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        IList<Comment> GetCommentsForPost(int postId);
        /// <summary>
        /// Get comments of a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        IList<Comment> GetCommentsForPost(Post post);
        /// <summary>
        /// Add comment to a post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentName"></param>
        /// <param name="commentEmail"></param>
        /// <param name="commentTitle"></param>
        /// <param name="commentBody"></param>
        void Add(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);
    }
}
