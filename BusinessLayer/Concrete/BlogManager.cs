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



        public void TAddBL(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDeleteBL(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdateBL(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory(); // todo Blog service de oluşturduğumuz metot ile EfblogDal da oluşturduğumuz metodu çağırıyoruz.
        }

        public Blog GetByID(int id)
        {
            return _blogDal.Get(x => x.BlogId == id);
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.FilterList(x => x.BlogId == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.List().Take(3).ToList();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.FilterList(x => x.WriterId == id);
        }


    }
}
