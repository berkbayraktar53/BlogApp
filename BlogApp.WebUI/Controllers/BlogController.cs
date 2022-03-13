using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            var values = _articleService.GetArticleListWithCategory();
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            ViewBag.id = id;
            var values = _articleService.GetById(id);
            return View(values);
        }
    }
}