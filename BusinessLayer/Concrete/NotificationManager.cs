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
    public class NotificationManager : INotificationService
    {
        INotificationDal _NotificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _NotificationDal = notificationDal;
        }

        public Notification GetByID(int id)
        {
            return _NotificationDal.Get(x => x.NotificationId == id);
        }

        public List<Notification> GetList()
        {
            return _NotificationDal.List().Where(x => x.NotificationStatus == true).ToList();
        }

        public List<Notification> GetByDesTake3List()
        {
            return _NotificationDal.List().Where(x => x.NotificationStatus == true).OrderByDescending(d => d.NotificationDate).Take(3).ToList();
        }

        public void TAddBL(Notification t)
        {
            _NotificationDal.Insert(t);
        }

        public void TDeleteBL(Notification t)
        {
            _NotificationDal.Delete(t);
        }

        public void TUpdateBL(Notification t)
        {
            _NotificationDal.Update(t);
        }
    }
}
