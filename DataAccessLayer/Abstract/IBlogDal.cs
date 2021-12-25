using EntityLayer.Concrete;
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
        List<Blog> GetListWithCategoryByWriter(int id); //incule metodu ile categori name getirdik
        List<Blog> GetBlogIdListWriter(int id); //include metodu ile blog id ye göre yazar adını aldık
        List<Blog> GetBlogCategoryWriterD(); //include admin tarafı için yazar category blog üçlüsü alınır
    }
}
