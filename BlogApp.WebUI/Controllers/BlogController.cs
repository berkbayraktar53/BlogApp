using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly INotyfService _notyfService;

        public BlogController(IArticleService articleService, INotyfService notyfService)
        {
            _articleService = articleService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            _notyfService.Success("Hoşgeldiniz");
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