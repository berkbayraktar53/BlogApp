using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApp.Business.Abstract;
using BlogApp.Business.ValidationRules.FluentValidation;
using BlogApp.Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly INotyfService _notyfService;

        public BlogController(IArticleService articleService, ICategoryService categoryService, INotyfService notyfService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _notyfService = notyfService;
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

        public IActionResult BlogListByWriter()
        {
            var values = _articleService.GetArticleListWithCategoryByWriter(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            List<SelectListItem> categoryValues = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.category = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Article article)
        {
            ArticleValidator rules = new();
            ValidationResult result = rules.Validate(article);
            if (result.IsValid)
            {
                article.Status = true;
                article.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                article.WriterId = 1;
                _articleService.Create(article);
                _notyfService.Success("Blog eklendi");
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            _notyfService.Error("Blog eklenemedi");
            return RedirectToAction("AddBlog", "Blog");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var values = _articleService.GetByArticleId(id);
            List<SelectListItem> categoryValues = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(values);
        }

        [HttpPost]
        public IActionResult EditBlog(Article article)
        {
            var values = _articleService.GetByArticleId(article.ArticleId);
            if (values != null)
            {
                article.WriterId = 1;
                article.Date = values.Date;
                article.Status = true;
                _articleService.Update(article);
                _notyfService.Success("Blog güncellendi");
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            _notyfService.Error("Blog güncellenemedi");
            return RedirectToAction("EditBlog", "Blog");
        }

        public IActionResult DeleteBlog(int id)
        {
            var values = _articleService.GetByArticleId(id);
            if (values != null)
            {
                _articleService.Delete(values);
                _notyfService.Success("Blog Silindi");
                return RedirectToAction("BlogListByWriter");
            }
            _notyfService.Error("Blog silinemedi");
            return RedirectToAction("DeleteBlog", "Blog");
        }
    }
}