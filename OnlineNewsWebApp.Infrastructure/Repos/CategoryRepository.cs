using OnlineNewsWebApp.Infrastructure.IRepos;
using OnlineNewsWebApp.Core.Entities;
using OnlineNewsWebApp.Infrastructure.Database;

namespace OnlineNewsWebApp.Infrastructure.Repos
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineNewsContext context) : base(context)
        {

        }
    }
}