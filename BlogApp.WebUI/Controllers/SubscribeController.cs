using BlogApp.Business.Abstract;
using BlogApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public IActionResult Index()
        {
            var values = _subscribeService.GetAll();
            return View(values);
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SubscribeMail(Subscribe subscribe)
        {
            subscribe.Status = true;
            _subscribeService.Create(subscribe);
            return PartialView();
        }
    }
}