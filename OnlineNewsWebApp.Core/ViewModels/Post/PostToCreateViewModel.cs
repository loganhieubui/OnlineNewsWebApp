using System.ComponentModel.DataAnnotations;

namespace OnlineNewsWebApp.Core.ViewModels.Post
{
    public class PostToCreateViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title must be required")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Url slug must be required")]
        public string UrlSlug { get; set; }

        [StringLength(1024, ErrorMessage = "Short description must not be longer than 1024 characters")]
        public string ShortDescription { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Post content must be required")]
        [StringLength(10000, ErrorMessage = "Post content must not be longer than 10000 characters")]
        public string PostContent { get; set; }

        public bool Published { get; set; }
        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; } = new List<int>();
    }
}
