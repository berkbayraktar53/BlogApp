using BlogApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessage2Service _message2Service;

        public MessageController(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }

        public IActionResult InBox()
        {
            int id = 1;
            var values = _message2Service.GetInboxListByWriter(id);
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            var values = _message2Service.GetById(id);
            return View(values);
        }
    }
}