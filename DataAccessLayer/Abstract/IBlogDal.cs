﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IRepository<Blog>
    {
        List<Blog> GetListWithCategory(); // todo Blogları categori ile birlikte getir. Bloga özel olduğu için Burada tanımlanır
    }
}
