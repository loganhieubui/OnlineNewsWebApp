namespace OnlineNewsWebApp.Core.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirm { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
