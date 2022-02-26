using BlogApp.Business.Concrete;
using BlogApp.DataAccess.Concrete.EntityFramework;
using BlogApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ArticleManager articleManager = new(new EfArticleDal());
            var values = articleManager.GetArticleListWithCategory();
            return View(values);
        }
    }
}