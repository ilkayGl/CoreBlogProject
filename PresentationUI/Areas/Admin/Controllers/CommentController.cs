using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;
using System.Threading.Tasks;
using BusinessLayer.Abstract;

namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly Context c = new();
        private readonly ICommentService _cms;
        private readonly IMessage2Service _ms;

        public CommentController(ICommentService cms, IMessage2Service ms)
        {
            _cms = cms;
            _ms = ms;
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



            var value = _cms.GetCommentBlogList().ToPagedList(page, 10);
            return View(value);
        }


        public IActionResult CommentDelete(int id)
        {
            var deleteValue = _cms.GetByID(id);
            _cms.TDeleteBL(deleteValue);
            return RedirectToAction("Index");
        }
    }
}
