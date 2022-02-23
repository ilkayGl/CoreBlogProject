using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly Context c = new();
        private readonly IAboutService _about;
        private readonly IMessage2Service _ms;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly INotyfService _notyf;

        public AboutController(IAboutService about, IMessage2Service ms, IWebHostEnvironment hostEnvironment, INotyfService notyf)
        {
            _about = about;
            _ms = ms;
            _hostEnvironment = hostEnvironment;
            _notyf = notyf;
        }


        public IActionResult AboutIndex()
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


            var value = _about.GetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult AboutAdd()
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
        public IActionResult AboutAdd(About w, AboutImageFileDTO about)
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



            var dosyaYolu = Path.Combine(_hostEnvironment.WebRootPath, "AboutImageFiles");
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
            var tamDosyaAdi = Path.Combine(dosyaYolu, about.AboutImage1.FileName);

            using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
            {
                about.AboutImage1.CopyTo(dosyaAkisi);
            }

            w.AboutImage1 = about.AboutImage1.FileName;

            w.AboutId = about.AboutId;
            w.AboutDetails1 = about.AboutDetails1;
            w.AboutDetails2 = about.AboutDetails2;
            w.AboutMapLocation = about.AboutMapLocation;
            w.AboutStatus = true;

            _about.TAddBL(w);
            _notyf.Success("Başarılı Bir Şekilde Eklendi.");
            return RedirectToAction("AboutIndex");
        }


        [HttpGet]
        public IActionResult AboutEdit()
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
        public IActionResult AboutEdit(About w, AboutImageFileDTO about)
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


            var dosyaYolu = Path.Combine(_hostEnvironment.WebRootPath, "AboutImageFiles");
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
            var tamDosyaAdi = Path.Combine(dosyaYolu, about.AboutImage1.FileName);

            using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
            {
                about.AboutImage1.CopyTo(dosyaAkisi);
            }

            w.AboutImage1 = about.AboutImage1.FileName;

            w.AboutId = about.AboutId;
            w.AboutDetails1 = about.AboutDetails1;
            w.AboutDetails2 = about.AboutDetails2;
            w.AboutMapLocation = about.AboutMapLocation;
            w.AboutStatus = true;

            _about.TUpdateBL(w);
            _notyf.Success("Güncelleme Başarılı.");
            return RedirectToAction("AboutIndex");
        }

        public IActionResult AboutDelete(int id)
        {
            var deleteValue = _about.GetByID(id);
            _about.TDeleteBL(deleteValue);
            _notyf.Error("Silme İşlemi Başarıyla Gerçekleşti.");
            return RedirectToAction("AboutIndex");
        }
    }
}
