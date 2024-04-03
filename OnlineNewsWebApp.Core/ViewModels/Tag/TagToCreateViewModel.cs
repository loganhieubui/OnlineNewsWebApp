using System.ComponentModel.DataAnnotations;

namespace OnlineNewsWebApp.Core.ViewModels.Tag
{
    public class TagToCreateViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name of tag must be required")]
        public string Name { get; set; }
        
        
    }
}
