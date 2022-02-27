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

        public List<Article>? GetById(int id)
        {
            return _articleDal.GetAll(x => x.ArticleId == id);
        }
    }
}