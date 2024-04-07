using OnlineNewsWebApp.Core.Entities;
using OnlineNewsWebApp.Core.ViewModels.Category;
using OnlineNewsWebApp.Core.ViewModels.Post;

namespace OnlineNewsWebApp.Core.ViewModels.Others
{
    public class PostsOf1Cate
    {
        public CategoryViewModel Cate { get; set; }
        public IList<PostViewModel> Posts { get; set; }
    }
}
