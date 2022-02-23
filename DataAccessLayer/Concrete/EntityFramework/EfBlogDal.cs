using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetBlogCategoryWriterD()
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Writer).Include(y => y.Category).OrderByDescending(d => d.BlogCreateDate).ToList();
            //admin tarafı için yazar category blog üçlüsü alınır
        }

        public List<Blog> GetBlogIdListWriter(int id)
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Writer).Where(x => x.BlogId == id).ToList(); //include metodu ile blog id ye göre yazar adını aldık
        }

        public List<Blog> GetListWithCategory()
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Category).Include(y => y.Writer).OrderByDescending(d => d.BlogCreateDate).Where(x => x.BlogStatus == true).ToList(); // todo Kategoriye ait değerleri (true) blog içerisine son yazılana (tarihe) göre  getirir.

        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using var c = new Context();
            return c.Blogs.Include(x => x.Category).Include(y => y.Writer).Where(x => x.WriterId == id).ToList(); // yazarın bloglarına ait kategorileri getir
        }
    }
}
