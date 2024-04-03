using System.ComponentModel.DataAnnotations;

namespace OnlineNewsWebApp.Core.ViewModels.Category
{
    public class CategoryToUpdateViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name of category must be required")]
        public string Name { get; set; }        
        
        [StringLength(1024, ErrorMessage = "Description must not be longer than 1024 characters")]
        public string Description { get; set; }
    }
}
