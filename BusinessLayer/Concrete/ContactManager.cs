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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }



        public Contact GetByID(int id)
        {
            return _contactDal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }

        public void TAddBL(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void TDeleteBL(Contact t)
        {
            _contactDal.Delete(t);
        }

        public void TUpdateBL(Contact t)
        {
            _contactDal.Update(t);
        }
    }
}
