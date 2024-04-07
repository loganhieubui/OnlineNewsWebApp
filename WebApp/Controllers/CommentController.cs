using Microsoft.AspNetCore.Mvc;
using OnlineNewsWebApp.Core.IServices;
using OnlineNewsWebApp.Core.ViewModels.Comment;

namespace OnlineNews.MVCWebApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult CommentsByPosts(int id)
        {
            var comments = _commentService.GetCommentsByPost(id);
            return PartialView("Components/_CommentsList", comments);
        }

        [HttpPost]
        public IActionResult AddComment([FromBody] CommentToCreateViewModel commentToCreate)
        {
            _commentService.Add(commentToCreate);
            return StatusCode(201);
        }
    }
}
