namespace OnlineNewsWebApp.Core.ViewModels.Others
{
    public class HomePageViewModel
    {
        public TrendingViewModel Trending { get; set; }
        public RecommendedViewModel Recommended { get; set; }
        public FirstPostOfCates FirstPostOfCates { get; set; }
        public IList<PostsOf1Cate> PostsOf1Cate { get; set; }
    }
}
