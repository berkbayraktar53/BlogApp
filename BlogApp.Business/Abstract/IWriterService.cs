using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll();
        void Create(Writer writer);
        Writer? GetByWriter(string email, string password);
    }
}