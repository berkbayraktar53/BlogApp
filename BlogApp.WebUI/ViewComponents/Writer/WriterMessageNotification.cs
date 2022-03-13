using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}