using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApp.Business.Abstract;
using BlogApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly INotyfService _notyfService;

        public ContactController(IContactService contactService, INotyfService notyfService)
        {
            _contactService = contactService;
            _notyfService = notyfService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.Status = true;
            _contactService.Create(contact);
            _notyfService.Success("Mesajınız gönderildi");
            return RedirectToAction("Index", "Blog");
        }
    }
}