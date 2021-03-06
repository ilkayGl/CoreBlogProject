using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Areas.Admin.ViewComponents.AdminMessageNotification
{
    public class MessageNotification : ViewComponent
    {
        private readonly Context c = new();
        private readonly IMessage2Service _ms;

        public MessageNotification(IMessage2Service ms)
        {
            _ms = ms;
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


            var values = _ms.GetInBoxListWriter(writerID).Take(3).OrderByDescending(x => x.MessageDate).ToList();
            return View(values);
        }
    }
}
