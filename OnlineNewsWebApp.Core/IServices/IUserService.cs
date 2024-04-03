using OnlineNewsWebApp.Core.ViewModels.User;

namespace OnlineNewsWebApp.Core.IServices
{
    public interface IUserService
    {
        bool Add(NewUserViewModel user);
        bool Update(EditUserViewModel user);
        bool Delete(string id);
        IList<UserViewModel> GetAll();
        IList<UserViewModel> GetPagedUsers(int page, int pageSize);
        UserDetailsViewModel GetDetails(string id);
        EditUserViewModel GetEditUser(string id);
        int CountAll();
    }
}
