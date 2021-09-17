using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }



        public void BlogAddBL(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public void BlogDeleteBL(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void BlogUpdateBL(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public Blog GetByID(int id)
        {
            return _blogDal.Get(x => x.BlogId == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }
    }
}
