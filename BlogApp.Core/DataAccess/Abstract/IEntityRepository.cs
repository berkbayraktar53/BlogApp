﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        T? GetOne(Expression<Func<T, bool>> filter);
        T? GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}