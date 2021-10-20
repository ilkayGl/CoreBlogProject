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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }



        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void TAddBL(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void TDeleteBL(Writer t)
        {
            _writerDal.Delete(t);
        }

        public void TUpdateBL(Writer t)
        {
            _writerDal.Update(t);
        }

    }
}
