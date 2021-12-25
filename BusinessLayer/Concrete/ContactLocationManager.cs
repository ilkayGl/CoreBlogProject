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
    public class ContactLocationManager : IContactLocationService
    {
        private readonly IContactLocationDal _ContactLocation;

        public ContactLocationManager(IContactLocationDal contactLocation)
        {
            _ContactLocation = contactLocation;
        }

        public ContactLocation GetByID(int id)
        {
            return _ContactLocation.Get(x => x.ContactLocationId == id);
        }

        public List<ContactLocation> GetList()
        {
            return _ContactLocation.List();
        }

        public void TAddBL(ContactLocation t)
        {
            _ContactLocation.Insert(t);
        }

        public void TDeleteBL(ContactLocation t)
        {
            _ContactLocation.Delete(t);
        }

        public void TUpdateBL(ContactLocation t)
        {
            _ContactLocation.Update(t);
        }
    }
}
