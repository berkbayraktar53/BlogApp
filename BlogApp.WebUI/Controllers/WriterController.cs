using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApp.Business.Abstract;
using BlogApp.Business.ValidationRules.FluentValidation;
using BlogApp.Entities.Concrete;
using BlogApp.WebUI.Models;
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
            var userMail = User.Identity?.Name;
            var writerId = _writerService.GetAll().Where(x => x.Email == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = _writerService.GetById(writerId);
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

        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWriter(AddProfileImage addProfileImage, Writer writer)
        {
            if (addProfileImage.Image != null)
            {
                var extension = Path.GetExtension(addProfileImage.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.Image.CopyTo(stream);
                writer.Image = newImageName;
            }
            writer.Email = addProfileImage.Email;
            writer.FirstName = addProfileImage.FirstName;
            writer.LastName = addProfileImage.LastName;
            writer.Password = addProfileImage.Password;
            writer.About = addProfileImage.About;
            writer.Date = DateTime.Now;
            writer.Status = true;
            _writerService.Create(writer);
            return RedirectToAction("Dashboard", "Writer");
        }
    }
}