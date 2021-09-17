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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAddBL(About about)
        {
            _aboutDal.Insert(about);
        }

        public void AboutDeleteBL(About about)
        {
            _aboutDal.Delete(about);
        }

        public void AboutUpdateBL(About about)
        {
            _aboutDal.Update(about);
        }

        public About GetByID(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }
    }
}
