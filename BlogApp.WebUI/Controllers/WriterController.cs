using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class WriterController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public WriterController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewBag.TotalBlog = _articleService.GetAll().Count;
            ViewBag.TotalBlogByWriter = _articleService.GetBlogListByWriter(1)?.Count;
            ViewBag.TotalCategory = _categoryService.GetAll().Count;
            return View();
        }
    }
}