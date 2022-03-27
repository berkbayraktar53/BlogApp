using BlogApp.Business.Abstract;
using BlogApp.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly IWriterService _writerService;

        public WriterAboutOnDashboard(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity?.Name;
            var writerId = _writerService.GetAll().Where(x => x.Email == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = _writerService.GetWriterById(writerId);
            return View(values);
        }
    }
}