using BlogApp.Core.DataAccess.Concrete.EntityFramework;
using BlogApp.DataAccess.Abstract;
using BlogApp.DataAccess.Concrete.EntityFramework.Context;
using BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article, BlogAppContext>, IArticleDal
    {
        public List<Article>? GetArticleListWithCategory()
        {
            using var context = new BlogAppContext();
            return context.Articles?.Include(x => x.Category).ToList();
        }
    }
}