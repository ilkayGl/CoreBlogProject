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
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());
        Context c = new Context();

        private readonly INotyfService _notyf;

        public MessageController(INotyfService notyf)
        {
            _notyf = notyf;
        }


        public IActionResult InBox()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            //int id = 1;
            var values = mm.GetInBoxListWriter(writerID);
            return View(values);
        }


        public IActionResult MessageDetails(int id)
        {
            var userMail = User.Identity.Name;
            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var value = mm.GetByID(id);
            return View(value);
        }

        public IActionResult MessageDelete(int id)
        {
            var values = mm.GetByID(id);
            if (values.MessageBool == true)
            {
                values.MessageBool = false;
                _notyf.Error("Mesaj Başarıyla Silindi.");
            }
            else
            {
                values.MessageBool = true;
                _notyf.Success("Mesaj Başarıyla Eklendi.");
            }
            mm.TUpdateBL(values);
            return RedirectToAction("InBox", "Message");
        }
    }
}
