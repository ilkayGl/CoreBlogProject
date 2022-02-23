using AspNetCoreHero.ToastNotification.Abstractions;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using X.PagedList;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Hosting;
using EntityLayer.DTOs;

namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        private readonly Context c = new();
        private readonly IWriterService _ws;
        private readonly IMessage2Service _ms;
        private readonly INotyfService _notyf;
        private readonly IWebHostEnvironment _hostEnvironment;

        public WriterController(IWriterService ws, IMessage2Service ms, INotyfService notyf, IWebHostEnvironment hostEnvironment)
        {
            _ws = ws;
            _ms = ms;
            _notyf = notyf;
            _hostEnvironment = hostEnvironment;
        }



        public IActionResult Index(int page = 1)
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

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;


            var value = _ws.GetList().ToPagedList(page, 9);
            return View(value);
        }


        [HttpGet]
        public IActionResult WriterAdd()
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

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;


            return View();
        }


        [HttpPost]
        public IActionResult WriterAdd(Writer w, AddProfileImageDTO p)
        {
            var dosyaYolu = Path.Combine(_hostEnvironment.WebRootPath, "WriterImageFiles"); //birleştir
            if (!Directory.Exists(dosyaYolu)) //yoksa
            {
                Directory.CreateDirectory(dosyaYolu); //oluştur
            }
            var tamDosyaAdi = Path.Combine(dosyaYolu, p.WriterImage.FileName); //wwwroote içine  dosya yolu tanımlıyor
                                                                               //file upload
            using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
            {
                p.WriterImage.CopyTo(dosyaAkisi);
            }//using ekleme amacımız Gc beklemeden kaynağı yok etmesidir.

            w.WriterImage = p.WriterImage.FileName;

            w.WriterId = p.WriterId;
            w.WriterName = p.WriterName;
            w.WriterMail = p.WriterMail;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            w.WriterRole = "B";
            w.WriterTitle = "Üye";
            _ws.TAddBL(w);

            _notyf.Success("Yazar Başarıyla Eklendi.");
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult WriterRole(int id)
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

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;


            var writerValues = _ws.GetByID(id);
            return View(writerValues);
        }


        [HttpPost]
        public IActionResult WriterRole(Writer w, AddProfileImageDTO p)
        {

            w.WriterId = p.WriterId;
            w.WriterName = p.WriterName;
            w.WriterMail = p.WriterMail;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            w.WriterRole = p.WriterRole;
            w.WriterTitle = p.WriterTitle;
            _ws.TUpdateBL(w);

            _notyf.Success("Başarıyla Güncellendi.");
            return RedirectToAction("Index");

        }

        public IActionResult WriterDelete(int id)
        {
            var deleteValue = _ws.GetByID(id);
            _notyf.Error("Başarıyla Silindi.");
            _ws.TDeleteBL(deleteValue);
            return RedirectToAction("Index");
        }

    }
}
