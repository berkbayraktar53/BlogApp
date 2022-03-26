using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}