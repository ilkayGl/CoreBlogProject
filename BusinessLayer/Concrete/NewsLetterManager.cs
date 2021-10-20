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
    public class NewsLetterManager : INewsLetterService
    {

        INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }



        public NewsLetter GetByID(int id)
        {
            return _newsLetterDal.Get(x => x.MailId == id);
        }

        public List<NewsLetter> GetList()
        {
            return _newsLetterDal.List();
        }

        public void TAddBL(NewsLetter t)
        {
            _newsLetterDal.Insert(t);
        }

        public void TDeleteBL(NewsLetter t)
        {
            _newsLetterDal.Delete(t);
        }

        public void TUpdateBL(NewsLetter t)
        {
            _newsLetterDal.Update(t);
        }
    }
}
