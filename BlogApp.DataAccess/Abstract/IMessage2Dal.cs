﻿using BlogApp.Core.DataAccess.Abstract;
using BlogApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccess.Abstract
{
    public interface IMessage2Dal : IEntityRepository<Message2>
    {
        List<Message2>? GetListWithMessageByWriter(int id);
    }
}