using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
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
            var values = _articleService.GetById(id);
            return View(values);
        }
    }
}