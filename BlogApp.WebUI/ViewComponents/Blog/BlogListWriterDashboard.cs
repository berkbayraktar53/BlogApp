using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Blog
{
    public class BlogListWriterDashboard : ViewComponent
    {
        private readonly IArticleService _articleService;

        public BlogListWriterDashboard(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.GetArticleListWithCategory();
            return View(values);
        }
    }
}