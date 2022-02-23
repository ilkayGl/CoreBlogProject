using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationUI.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        private readonly Context c = new();
        private readonly IBlogService _bs;

        public BlogListDashboard(IBlogService bs)
        {
            _bs = bs;
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

            var values = _bs.GetBlogListWithCategory().OrderByDescending(x => x.BlogCreateDate).Take(10).ToList();
            return View(values);
        }
    }
}
