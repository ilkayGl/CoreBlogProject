using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Areas.Admin.ViewComponents.ContactMessage
{
    public class ContactMessage : ViewComponent
    {
        private readonly Context c = new();
        private readonly IContactService _cs;

        public ContactMessage(IContactService cs)
        {
            _cs = cs;
        }

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var contactMessages = _cs.GetList().Count().ToString();
            ViewBag.contactMessages = contactMessages;

            var values = _cs.GetList().Take(3).OrderByDescending(x => x.ContactDate).ToList();
            return View(values);
        }

    }
}
