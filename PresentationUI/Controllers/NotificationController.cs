using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationDal());
        Context c = new Context();
        private readonly INotyfService _notyf;

        public NotificationController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotification()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var values = nm.GetList();
            return View(values);
        }

        public IActionResult NotificationDelete(int id)
        {
            var remove = nm.GetByID(id);
            nm.TDeleteBL(remove);
            _notyf.Error("Bildirim Başarıyla Silindi.");
            return RedirectToAction("AllNotification", "Notification");
        }
    }
}
