using Microsoft.AspNetCore.Identity;

namespace OnlineNewsWebApp.Core.Entities
{
    public class User : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [PersonalData]
        public int Age { get; set; }
        [PersonalData]
        public string AboutMe { get; set; }

        public int DonationStars { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
