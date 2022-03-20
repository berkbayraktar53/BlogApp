using BlogApp.Business.Abstract;
using BlogApp.DataAccess.Abstract;
using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public List<Article>? GetArticleListWithCategory()
        {
            return _articleDal.GetArticleListWithCategory();
        }

        public List<Article>? GetBlogListByWriter(int id)
        {
            return _articleDal.GetAll(x => x.WriterId == id);
        }

        public List<Article>? GetArticleListWithCategoryByWriter(int id)
        {
            return _articleDal.GetArticleListWithCategoryByWriter(id);
        }

        public List<Article>? GetById(int id)
        {
            return _articleDal.GetAll(x => x.ArticleId == id);
        }

        public List<Article>? GetLast3Article()
        {
            return _articleDal.GetAll().TakeLast(3).OrderByDescending(x => x.ArticleId).ToList();
        }

        public void Create(Article article)
        {
            _articleDal.Create(article);
        }

        public void Delete(Article article)
        {
            _articleDal.Delete(article);
        }

        public Article? GetByArticleId(int id)
        {
            return _articleDal.GetById(id);
        }

        public void Update(Article article)
        {
            _articleDal.Update(article);
        }

        public List<Article> GetAll()
        {
            return _articleDal.GetAll();
        }
    }
}