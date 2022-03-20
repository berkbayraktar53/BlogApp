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
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Create(Writer writer)
        {
            _writerDal.Create(writer);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer? GetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public Writer? GetByWriter(string email, string password)
        {
            return _writerDal.GetOne(x => x.Email == email && x.Password == password);
        }

        public List<Writer>? GetWriterById(int id)
        {
            return _writerDal.GetAll(x => x.WriterId == id);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}