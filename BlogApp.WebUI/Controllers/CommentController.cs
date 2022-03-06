using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApp.Business.Abstract;
using BlogApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly INotyfService _notyfService;

        public CommentController(ICommentService commentService, INotyfService notyfService)
        {
            _commentService = commentService;
            _notyfService = notyfService;
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var values = _commentService.GetAll(id);
            return PartialView(values);
        }

        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.Status = true;
            comment.Date = DateTime.Now;
            comment.ArticleId = 1;
            _commentService.Create(comment);
            _notyfService.Success("Yorumunuz eklendi");
            return RedirectToAction("Detail", "Blog");
        }
    }
}