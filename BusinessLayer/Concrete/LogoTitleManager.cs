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
    public class LogoTitleManager : ILogoTitleService
    {
        ILogoTitleDal _logoTitleDal;

        public LogoTitleManager(ILogoTitleDal logoTitleDal)
        {
            _logoTitleDal = logoTitleDal;
        }

        public LogoTitle GetByID(int id)
        {
            return _logoTitleDal.Get(x => x.LogoTitleId == id);
        }

        public List<LogoTitle> GetList()
        {
            return _logoTitleDal.List();
        }

        public void TAddBL(LogoTitle t)
        {
            _logoTitleDal.Insert(t);
        }

        public void TDeleteBL(LogoTitle t)
        {
            _logoTitleDal.Delete(t);
        }

        public void TUpdateBL(LogoTitle t)
        {
            _logoTitleDal.Update(t);
        }
    }
}
