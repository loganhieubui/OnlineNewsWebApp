using System.ComponentModel.DataAnnotations;

namespace OnlineNewsWebApp.Core.ViewModels.Role
{
    public class RoleViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
