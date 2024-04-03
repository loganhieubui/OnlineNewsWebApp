using OnlineNewsWebApp.Core.ViewModels.Category;

namespace OnlineNewsWebApp.Core.IServices
{
    public interface ICategoryService
    {
        IList<CategoryViewModel> GetAllCategories();
        IList<CategoryViewModel> GetPagedCategories(int page, int pageSize);
        /// <summary>
        /// Get the (pageSize) categories recoreds in the (page)th page
        /// apply in DataTableViewModel
        /// </summary>
        /// <returns></returns>
        int CountCategories();
        bool Delete(int id);
        bool Add(CategoryToCreateViewModel categoryToCreate);
        bool Update(CategoryToUpdateViewModel categoryToUpdate);
        CategoryToUpdateViewModel GetCategoryToUpdateById(int id);
        CategoryDetailsViewModel GetDetails(int id);
    }
}
