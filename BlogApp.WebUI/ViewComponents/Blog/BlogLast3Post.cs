using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        private readonly IArticleService _articleService;

        public BlogLast3Post(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.GetLast3Article();
            return View(values);
        }
    }
}