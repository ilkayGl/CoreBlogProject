using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LogoTitleController : Controller
    {
        private readonly Context c = new();
        private readonly ILogoTitleService _lts;
        private readonly IMessage2Service _ms;
        private readonly INotyfService _notyf;
        private readonly IWebHostEnvironment _hostEnvironment;

        public LogoTitleController(ILogoTitleService lts, IMessage2Service ms, INotyfService notyf, IWebHostEnvironment hostEnvironment)
        {
            _lts = lts;
            _ms = ms;
            _notyf = notyf;
            _hostEnvironment = hostEnvironment;
        }



        public IActionResult Index()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;




            var value = _lts.GetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult LogoTitleAdd()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;


            return View();
        }

        [HttpPost]
        public IActionResult LogoTitleAdd(LogoTitle l, LogoImageFileDTO logoTitle)
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;


            var dosyaYolu = Path.Combine(_hostEnvironment.WebRootPath, "LogoImageFiles");
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
            var tamDosyaAdi = Path.Combine(dosyaYolu, logoTitle.Logo.FileName);

            using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
            {
                logoTitle.Logo.CopyTo(dosyaAkisi);
            }

            l.Logo = logoTitle.Logo.FileName;

            l.LogoTitleId = logoTitle.LogoTitleId;
            l.Title = logoTitle.Title;
            l.Status = true;

            _lts.TAddBL(l);
            _notyf.Success("Logo Başarıyla Eklendi.");
            return RedirectToAction("Index");
        }


        public IActionResult LogoTitleDelete(int id)
        {
            var delete = _lts.GetByID(id);
            _lts.TDeleteBL(delete);
            _notyf.Error("Logo Başarıyla Silindi.");
            return RedirectToAction("Index");
        }

    }
}
