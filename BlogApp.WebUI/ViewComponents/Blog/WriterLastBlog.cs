using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        private readonly IArticleService _articleService;

        public WriterLastBlog(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.GetBlogListByWriter(1);
            return View(values);
        }
    }
}