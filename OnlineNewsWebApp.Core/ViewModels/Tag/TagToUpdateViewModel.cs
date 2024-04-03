using System.ComponentModel.DataAnnotations;

namespace OnlineNewsWebApp.Core.ViewModels.Tag
{
    public class TagToUpdateViewModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name of tag must be required")]
        public string Name { get; set; }
        
        
    }
}
