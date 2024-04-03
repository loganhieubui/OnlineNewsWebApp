using OnlineNewsWebApp.Core.ViewModels.Tag;

namespace OnlineNewsWebApp.Core.IServices
{
    public interface ITagService
    {
        IList<TagViewModel> GetTopTags(int size);
        IList<TagViewModel> GetPagedTags(int page, int pageSize);
        int CountAllTags();
        bool Delete(int id);
        bool Add(TagToCreateViewModel tagToCreate);
        IList<TagViewModel> GetAllTags();
        TagToUpdateViewModel GetTagToUpdate(int id);
        bool Update(TagToUpdateViewModel tagToUpdate);
        TagDetailsViewModel GetDetailOfTags(int id);
    }
}
