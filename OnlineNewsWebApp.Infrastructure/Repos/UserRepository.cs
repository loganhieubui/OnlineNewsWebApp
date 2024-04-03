using OnlineNewsWebApp.Infrastructure.IRepos;
using OnlineNewsWebApp.Core.Entities;
using OnlineNewsWebApp.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;

namespace OnlineNewsWebApp.Infrastructure.Repos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(OnlineNewsContext context) : base(context)
        {
        }

        public IList<IdentityRole> GetRoles(string id)
        {
            var roleIds = Context.UserRoles.Where(ur => ur.UserId == id).Select(ur => ur.RoleId).ToList();
            return Context.Roles.Where(r => roleIds.Contains(r.Id)).ToList();
        }
        public void AddRoles(string id, IList<string> roleIds)
        {
            var userRoles = roleIds.Select(roleId => new IdentityUserRole<string>
            {
                UserId = id,
                RoleId = roleId
            });
            Context.UserRoles.AddRange(userRoles);
        }

        public void DeleteRoles(string id)
        {
            Context.UserRoles.RemoveRange(Context.UserRoles.Where(ur => ur.UserId == id));
        }
    }
}
