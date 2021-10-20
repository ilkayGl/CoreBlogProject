using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetBlogListWithCategory(); // todo Include için  list metodu oluşturuldu categoriye göre listele

        List<Blog> GetBlogListByWriter(int id);
    }
}
