using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Category
{
    public class CategoryListWriterDashboard : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryListWriterDashboard(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.GetAll();
            return View(values);
        }
    }
}