using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Abstract
{
    public interface IArticleService
    {
        List<Article>? GetArticleListWithCategory();
        List<Article>? GetBlogListByWriter(int id);
        List<Article>? GetById(int id);
        List<Article>? GetLast3Article();
    }
}