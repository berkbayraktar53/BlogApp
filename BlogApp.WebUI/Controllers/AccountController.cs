using BlogApp.Business.Abstract;
using BlogApp.Business.ValidationRules.FluentValidation;
using BlogApp.Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWriterService _writerService;

        public AccountController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Writer writer)
        {
            WriterValidator rules = new();
            ValidationResult result = rules.Validate(writer);
            if (result.IsValid)
            {
                writer.Status = true;
                writer.Date = DateTime.Now;
                writer.About = "Test";
                _writerService.Create(writer);
                return RedirectToAction("Index", "Blog");
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