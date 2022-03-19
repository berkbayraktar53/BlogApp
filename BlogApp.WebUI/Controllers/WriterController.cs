using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}