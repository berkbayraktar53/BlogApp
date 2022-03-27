using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApp.Business.Abstract;
using BlogApp.Business.ValidationRules.FluentValidation;
using BlogApp.Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly INotyfService _notyfService;

        public AccountController(IWriterService writerService, INotyfService notyfService)
        {
            _writerService = writerService;
            _notyfService = notyfService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var getWriter = _writerService.GetByWriter(email, password);
            if (getWriter != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email)
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new(userIdentity);
                await HttpContext.SignInAsync(principal);
                //_notyfService.Success("Giriş yapıldı");
                return RedirectToAction("Dashboard", "Writer");
            }
            else
            {
                _notyfService.Error("Giriş yapılamadı");
                return View();
            }
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