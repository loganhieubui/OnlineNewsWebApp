using OnlineNewsWebApp.Core.ViewModels.Role;

namespace OnlineNewsWebApp.Core.ViewModels.User
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Age { get; set; }
        public string AboutMe { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirm { get; set; }
        public IList<RoleViewModel> Roles { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
