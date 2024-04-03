using OnlineNewsWebApp.Core.ViewModels.Comment;

namespace OnlineNewsWebApp.Core.IServices
{
    public interface ICommentService
    {
        IList<CommentViewModel> GetCommentsByPost(int postId);
        bool Add(CommentToCreateViewModel commentToCreate);
        IList<CommentViewModel> GetPagedComments(int page, int pageSize);
        int CountAllComments();
        bool Delete(int id);
        CommentToUpdateViewModel GetCommentToUpdate(int id);
        bool Update(CommentToUpdateViewModel commentToUpdate);
        CommentDetailsViewModel GetDetails(int id);
    }
}
