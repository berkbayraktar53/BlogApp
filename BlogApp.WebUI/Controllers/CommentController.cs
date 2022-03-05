using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var values = _commentService.GetAll(id);
            return PartialView(values);
        }

        public PartialViewResult AddComment()
        {
            return PartialView();
        }
    }
}