using System.ComponentModel.DataAnnotations;

namespace OnlineNewsWebApp.Core.ViewModels.User
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string AboutMe { get; set; }
        public IList<string> RoleIds { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
