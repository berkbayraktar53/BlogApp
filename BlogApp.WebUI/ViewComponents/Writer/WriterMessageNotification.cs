using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly IMessageService _messageService;

        public WriterMessageNotification(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public IViewComponentResult Invoke()
        {
            string receiver = "keremberk53@hotmail.com";
            var values = _messageService.GetInboxListByWriter(receiver);
            return View(values);
        }
    }
}