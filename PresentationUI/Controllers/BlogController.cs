using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }


        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id; // todo =* ViewComment= BlogId ye göre yorum getirmek için id yi çekiyoruz BlogReadAll.cshtl Vc id olarak atıyoruz
            var values = bm.GetBlogByID(id);
            return View(values);
        }
    }
}
