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
        List<Article> GetAll();
        List<Article>? GetLast3Article();
        List<Article>? GetArticleListWithCategoryByWriter(int id);
        Article? GetByArticleId(int id);
        void Create(Article article);
        void Delete(Article article);
        void Update(Article article);
    }
}