using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactLocationController : Controller
    {
        private readonly Context c = new();
        private readonly IContactLocationService _cls;
        private readonly IMessage2Service _ms;

        public ContactLocationController(IContactLocationService cls, IMessage2Service ms)
        {
            _cls = cls;
            _ms = ms;
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

            var values = _cls.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult ContactLocationAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactLocationAdd(ContactLocation c)
        {
            c.ContactStatus = true;
            _cls.TAddBL(c);

            return RedirectToAction("Index");
        }

        public IActionResult ContactLocationDelete(int id)
        {
            var delete = _cls.GetByID(id);
            _cls.TDeleteBL(delete);
            return RedirectToAction("Index");
        }
    }
}
