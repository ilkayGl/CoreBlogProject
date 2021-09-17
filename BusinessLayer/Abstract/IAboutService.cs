using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();

        void AboutAddBL(About about);

        void AboutDeleteBL(About about);

        void AboutUpdateBL(About about);

        About GetByID(int id);
    }
}
