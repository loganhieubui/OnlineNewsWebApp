using Microsoft.AspNetCore.Mvc;
using OnlineNewsWebApp.Core.IServices;

namespace OnlineNews.MVCWebApp.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IPostService _postService;
        public TagController(ITagService tagService, IPostService postService)
        {
            _tagService = tagService;
            _postService = postService;
        }

        [Route("tag/partialview/populartags")]
        public IActionResult PopularTags()
        {
            int size = 5;
            var tags = _tagService.GetTopTags(size);
            return PartialView("Components/_PopularTagsPartial", tags);
        }

        [Route("tag/{slug}")]
        public IActionResult Details(string slug)
        {
            var posts = _postService.GetPostsByTag(slug);
            return View("~/Views/Post/Index.cshtml", posts);
        }
    }
}
