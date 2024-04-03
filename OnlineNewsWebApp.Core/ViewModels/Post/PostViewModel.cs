using OnlineNewsWebApp.Core.Entities;
using OnlineNewsWebApp.Core.ViewModels.Tag;
using OnlineNewsWebApp.Core.ViewModels.Category;


namespace OnlineNewsWebApp.Core.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlSlug { get; set; }
        public DateTime PostedOn { get; set; }
        public decimal Rate { get; set; }
        public int ViewCount { get; set; }
        public string ShortDescription { get; set; }
        public IList<TagViewModel> Tags { get; set; }
        public CategoryViewModel Category { get; set; }
        public string AuthorName { get; set; }
    }
}
