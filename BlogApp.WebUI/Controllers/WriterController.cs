using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApp.Business.Abstract;
using BlogApp.Business.ValidationRules.FluentValidation;
using BlogApp.Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class WriterController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;
        private readonly INotyfService _notyfService;

        public WriterController(IArticleService articleService, ICategoryService categoryService, IWriterService writerService, INotyfService notyfService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _writerService = writerService;
            _notyfService = notyfService;
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

        [HttpGet]
        public IActionResult EditProfile()
        {
            var values = _writerService.GetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);
            if (result.IsValid)
            {
                writer.Date = DateTime.Now;
                writer.Status = true;
                _writerService.Update(writer);
                _notyfService.Success("Güncelleme başarılı");
                return RedirectToAction("Dashboard", "Writer");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}