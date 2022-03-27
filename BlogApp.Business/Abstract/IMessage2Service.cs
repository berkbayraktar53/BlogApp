using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Abstract
{
    public interface IMessage2Service
    {
        List<Message2>? GetInboxListByWriter(int id);
        Message2? GetById(int id);
    }
}