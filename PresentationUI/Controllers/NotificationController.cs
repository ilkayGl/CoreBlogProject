using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly Context c = new();
        private readonly INotificationService _ns;
        private readonly INotyfService _notyf;

        public NotificationController(INotificationService ns, INotyfService notyf)
        {
            _ns = ns;
            _notyf = notyf;
        }




        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NotificationAdd()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();


            return View();
        }

        [HttpPost]
        public IActionResult NotificationAdd(EntityLayer.Concrete.Notification n)
        {
            n.NotificationStatus = true;
            _ns.TAddBL(n);
            return RedirectToAction("AllNotification");
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

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();

            var values = _ns.GetList();
            return View(values);
        }

        public IActionResult NotificationDelete(int id)
        {
            var remove = _ns.GetByID(id);
            _ns.TDeleteBL(remove);
            _notyf.Error("Bildirim Başarıyla Silindi.");
            return RedirectToAction("AllNotification", "Notification");
        }
    }
}
