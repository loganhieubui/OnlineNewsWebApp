using OnlineNewsWebApp.Core.Entities;

namespace OnlineNewsWebApp.Infrastructure.IRepos
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        /// <summary>
        /// Get last posts inserted
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetLatestPost(int size);

        /// <summary>
        /// Get posts with a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        IList<Post> GetPostsByCategory(string category);

        /// <summary>
        /// Get posts with a tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        IList<Post> GetPostsByTag(string tag);

        /// <summary>
        /// Get most viewed posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetMostViewedPosts(int size);

        /// <summary>
        /// Get highest rated (highly recommended) posts
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetHighestPosts(int size);

        /// <summary>
        /// Get all post with category and tags
        /// </summary>
        /// <returns></returns>
        IList<Post> GetAllPostsWithCategoryAndTags();

        /// <summary>
        /// Add new list tag in post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="tagIds"></param>
        void AddTags(int postId, IList<int> tagIds);

        /// <summary>
        /// Update tag in post
        /// </summary>
        /// <param name="postId"></param>
        void DeleteTags(int postId);


        /// <summary>
        /// Get post with Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Post GetPostWithTags(int id);

        /// <summary>
        /// Get post with year and month and url slug
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Post GetDetails(int year, int month, string urlSlug);

        IList<Post> GetPostsByTitle(string title);
        
    }
}
