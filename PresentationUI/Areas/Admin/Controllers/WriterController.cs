using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using X.PagedList;
using System.Threading.Tasks;
using BusinessLayer.Abstract;

namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        private readonly Context c = new();
        private readonly IWriterService _ws;
        private readonly IMessage2Service _ms;
        private readonly INotyfService _notyf;

        public WriterController(IWriterService ws, IMessage2Service ms, INotyfService notyf)
        {
            _ws = ws;
            _ms = ms;
            _notyf = notyf;
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


            return View();
        }


        [HttpPost]
        public IActionResult WriterAdd(WriterImageFileAdd p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimageName;
            }
            w.WriterName = p.WriterName;
            w.WriterMail = p.WriterMail;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            _ws.TAddBL(w);
            _notyf.Success("Başarıyla Eklendi.");
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


            var writerValues = _ws.GetByID(id);
            return View(writerValues);
        }


        [HttpPost]
        public IActionResult WriterRole(Writer w, WriterImageFileAdd p)
        {
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimageName;
            }
            w.WriterId = p.WriterId;
            w.WriterName = p.WriterName;
            w.WriterMail = p.WriterMail;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            w.WriterRole = p.WriterRole;
            w.WriterTitle = p.WriterTitle;

            _notyf.Success("Başarıyla Güncellendi.");
            _ws.TUpdateBL(w);
            return RedirectToAction("Index");

        }

        public IActionResult WriterDelete(int id)
        {
            var deleteValue = _ws.GetByID(id);
            _ws.TDeleteBL(deleteValue);
            return RedirectToAction("Index");
        }

    }
}
