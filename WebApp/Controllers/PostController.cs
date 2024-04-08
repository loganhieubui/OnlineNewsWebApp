using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using OnlineNewsWebApp.Core.IServices;

namespace OnlineNews.MVCWebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: PostController
        public IActionResult Index()
        {
            var posts = _postService.GetAllPostsWithCategoryAndTags();
            return View(posts);
        }

        [Route("Latest")]
        public IActionResult LatestPosts()
        {
            int size = 5;
            var posts = _postService.GetLatestPosts(size);
            return PartialView("Components/_ListPostsPartial", posts);
        }
        public IActionResult MostViewedPosts()
        {
            int size = 5;
            var posts = _postService.GetMostViewedPosts(size);
            return PartialView("Components/_ListPostsPartial", posts);
        }

        [Route("post/{year}/{month}/{slug}")]
        public IActionResult Details(int year, int month, string slug)
        {
            var post = _postService.GetDetailOfPosts(year, month, slug);
            if (post == null)
                return View("Components/NotFound");
            return View(post);
        }

        //[Route("post/{id}")]
        public IActionResult Details(int id)
        {
            var post = _postService.GetDetailOfPosts(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult SearchResult(string keyword)
        {
            var post1 = _postService.GetPostsByTag(keyword);
            var post2 = _postService.SearchPosts(keyword);
            post2.AddRange(post1);
            if (post2 == null)
            {
                return PartialView("Components/NotFound");
            }
            return View("Components/_ListPostsPartial", post2);
        }
    }
}
