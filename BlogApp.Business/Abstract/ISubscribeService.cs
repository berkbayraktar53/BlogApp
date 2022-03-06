using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Abstract
{
    public interface ISubscribeService
    {
        List<Subscribe> GetAll();
        void Create(Subscribe subscribe);
    }
}