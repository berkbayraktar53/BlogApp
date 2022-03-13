using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}