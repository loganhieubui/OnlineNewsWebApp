using OnlineNewsWebApp.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace OnlineNewsWebApp.Infrastructure.IRepos
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Get role of user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<IdentityRole> GetRoles(string id);

        /// <summary>
        /// Add role
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleIds"></param>
        void AddRoles(string id, IList<string> roleIds);

        /// <summary>
        /// Remove role
        /// </summary>
        /// <param name="id"></param>
        void DeleteRoles(string id);
    }
}
