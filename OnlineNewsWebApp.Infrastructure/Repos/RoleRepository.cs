using OnlineNewsWebApp.Infrastructure.IRepos;
using OnlineNewsWebApp.Core.Entities;
using OnlineNewsWebApp.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;

namespace OnlineNewsWebApp.Infrastructure.Repos
{
    public class RoleRepository : GenericRepository<IdentityRole>, IRoleRepository
    {
        public RoleRepository(OnlineNewsContext context) : base(context)
        {
        }
    }
}
