using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public WriterNotification(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _notificationService.GetAll().OrderByDescending(x => x.NotificationId).Take(3).ToList();
            return View(values);
        }
    }
}