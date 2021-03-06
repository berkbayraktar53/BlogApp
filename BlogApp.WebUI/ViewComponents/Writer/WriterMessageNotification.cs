using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessage2Service _message2Service;

        public WriterMessageNotification(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }
        public IViewComponentResult Invoke()
        {
            int id = 1;
            var values = _message2Service.GetInboxListByWriter(id);
            return View(values);
        }
    }
}