using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OnlineNewsWebApp.Core.ViewModels.Others;
using OnlineNewsWebApp.Infrastructure.IRepos;
using OnlineNewsWebApp.Core.IServices;
using OnlineNewsWebApp.Core.ViewModels.Post;

namespace OnlineNews.MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, IPostService postService, ICategoryService categoryService)
        {
            _logger = logger;
            _postService = postService;
            _categoryService = categoryService;
        }

        
        public IActionResult Index()
        {
            var trending_posts = _postService.GetMostViewedPosts(5);
            var trending_obj = new TrendingViewModel
            {
                Posts = trending_posts
            };
            var recommended_posts = _postService.GetRecommendedPosts(5);
            var recommended_obj = new RecommendedViewModel { Posts = recommended_posts };
            var categories = _categoryService.GetAllCategories();
            var list_po1c = new List<PostsOf1Cate>();
            var fps = new List<PostViewModel>();
            foreach (var c in categories)
            {
                var ps = _postService.GetPostsByCategory(c.Name);
                fps.Add(ps[0]);
                list_po1c.Add(new PostsOf1Cate { Posts = ps, Cate = c });
            }

            var fpoc = new FirstPostOfCates
            {
                Posts = fps,
                Cates = categories,
                Trending = trending_obj
            };
            var hpvm = new HomePageViewModel
            {
                Trending = trending_obj,
                Recommended = recommended_obj,
                FirstPostOfCates = fpoc,
                PostsOf1Cate = list_po1c

            };
            return View(hpvm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
