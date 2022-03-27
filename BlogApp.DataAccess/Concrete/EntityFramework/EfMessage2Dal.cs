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
    public class EfMessage2Dal : EfEntityRepositoryBase<Message2, BlogAppContext>, IMessage2Dal
    {
        public List<Message2>? GetListWithMessageByWriter(int id)
        {
            using var context = new BlogAppContext();
            return context.Message2s?.Include(x => x.SenderUser).Where(x => x.ReceiverId == id).ToList();
        }
    }
}