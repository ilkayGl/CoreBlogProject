using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetList();

        void BlogAddBL(Blog blog);

        void BlogDeleteBL(Blog blog);

        void BlogUpdateBL(Blog blog);

        Blog GetByID(int id);

        List<Blog> GetBlogListWithCategory(); // todo Include için  list metodu oluşturuldu
    }
}
