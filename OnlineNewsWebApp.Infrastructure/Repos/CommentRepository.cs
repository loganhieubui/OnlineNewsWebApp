using OnlineNewsWebApp.Infrastructure.IRepos;
using OnlineNewsWebApp.Core.Entities;
using OnlineNewsWebApp.Infrastructure.Database;

namespace OnlineNewsWebApp.Infrastructure.Repos
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(OnlineNewsContext context) : base(context) { }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            var c = Context.Comments!.ToList();
            return Context.Comments!.Where(c => c.PostId == postId).ToList();
        }
        public IList<Comment> GetCommentsForPost(Post post)
        {
            return Context.Comments!.Where(c => c.PostId == post.Id).ToList();
        }

        public void Add(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment()
            {
                PostId = postId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now
            };
            Context.Comments!.Add(comment);
        }
    }
}
