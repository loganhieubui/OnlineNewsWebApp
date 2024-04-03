using System.ComponentModel.DataAnnotations;

namespace OnlineNewsWebApp.Core.ViewModels.User
{
    public class NewUserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string AboutMe { get; set; }
        public IList<string> Roles { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
