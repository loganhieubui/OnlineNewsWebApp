using OnlineNewsWebApp.Core.ViewModels.Category;
using OnlineNewsWebApp.Core.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNewsWebApp.Core.ViewModels.Others
{
    public class FirstPostOfCates
    {
        public IList<CategoryViewModel> Cates { get; set; }
        public IList<PostViewModel> Posts { get; set; }

        public TrendingViewModel Trending { get; set; }
    }
}
