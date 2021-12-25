using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
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

        public List<Blog> GetBlogIdListWriter(int id)
        {
            return _blogDal.GetBlogIdListWriter(id); //include metodu ile blog id ye göre yazar adını aldık
        }


        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.List().OrderByDescending(d => d.BlogCreateDate).Where(x => x.BlogStatus == true).Take(3).ToList();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.FilterList(x => x.WriterId == id).OrderByDescending(d => d.BlogCreateDate).Where(y => y.BlogStatus == true).Take(3).ToList();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id).OrderByDescending(d => d.BlogCreateDate).ToList();
        }

        public List<Blog> GetBlogCategoryWriter()
        {
            return _blogDal.GetBlogCategoryWriterD();
        }

    }
}
