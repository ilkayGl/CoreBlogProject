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



        public About GetByID(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }

        public void TAddBL(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDeleteBL(About t)
        {
            _aboutDal.Delete(t);
        }

        public void TUpdateBL(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
