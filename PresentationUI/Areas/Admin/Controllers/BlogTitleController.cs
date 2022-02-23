using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using X.PagedList;
using BusinessLayer.Abstract;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogTitleController : Controller
    {
        private readonly Context c = new();
        private readonly IBlogService _bs;
        private readonly IMessage2Service _ms;
        private readonly INotyfService _notyf;

        public BlogTitleController(IBlogService bs, IMessage2Service ms, INotyfService notyf)
        {
            _bs = bs;
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


            var value = _bs.GetBlogCategoryWriter().ToPagedList(page, 10);
            return View(value);
        }


        public IActionResult BlogRemove(int id)
        {
            var deleteValue = _bs.GetByID(id);
            _bs.TDeleteBL(deleteValue);
            _notyf.Error("Blog Başarıyla Silindi.");
            return RedirectToAction("Index");
        }


    }
}
