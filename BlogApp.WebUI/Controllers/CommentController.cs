using BlogApp.Business.Abstract;
using BlogApp.Entities.Concrete;
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

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddComment(Comment comment)
        {
            comment.Status = true;
            comment.Date = DateTime.Now;
            comment.ArticleId = 1;
            _commentService.Create(comment);
            return PartialView();
        }
    }
}