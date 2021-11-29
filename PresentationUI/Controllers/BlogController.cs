using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace PresentationUI.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();

        private readonly INotyfService _notyf;

        public BlogController(INotyfService notyf)
        {
            _notyf = notyf;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(int? Sayfa, string Blogsearch)
        {
            var pageNumber = Sayfa ?? 1;
            int pagaSize = 9;
            ViewData["blogall"] = Blogsearch;
            //var values = c.GetBlogListWithCategory();
            var values = from x in c.Blogs.Include(x => x.Category).Include(x => x.Writer).OrderByDescending(d => d.BlogCreateDate).Where(s => s.BlogStatus == true) select x;
            if (!String.IsNullOrEmpty(Blogsearch))
            {
                values = values.Where(x => x.BlogTitle.Contains(Blogsearch) || x.Category.CategoryName.Contains(Blogsearch) || x.Writer.WriterName.Contains(Blogsearch));

            }
            return View(values.AsNoTracking().ToList().ToPagedList(pageNumber, pagaSize));
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id; // todo =* ViewComment= BlogId ye göre yorum getirmek için id yi çekiyoruz BlogReadAll.cshtl Vc id olarak atıyoruz
            var values = bm.GetBlogIdListWriter(id);
            return View(values);
        }


        public IActionResult BlogListByWriterr()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }


        [HttpGet]
        public IActionResult BlogAdd()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;


            List<SelectListItem> deger1 = (from x in cm.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()

                                           }).ToList();



            ViewBag.dgr1 = deger1;

            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;



            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerID;
                bm.TAddBL(blog);
                _notyf.Success("Blog Başarıyla Eklendi.");
                return RedirectToAction("BlogListByWriterr", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    _notyf.Warning("Blog Eklenirken Bir Hata Oluştur");
                }
            }
            return View();

        }


        public IActionResult BlogDelete(int id)
        {
            var values = bm.GetByID(id);
            if (values.BlogStatus == true)
            {
                values.BlogStatus = false;
                _notyf.Error("Blog Başarıyla Silindi.");
            }
            else
            {
                values.BlogStatus = true;
                _notyf.Success("Blog Başarıyla Eklendi.");
            }
            bm.TUpdateBL(values);
            return RedirectToAction("BlogListByWriterr", "Blog");
        }

        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;


            var blogValue = bm.GetByID(id);
            List<SelectListItem> deger1 = (from x in cm.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()

                                           }).ToList();



            ViewBag.dgr1 = deger1;
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog blog)
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.WriterId = writerID;
                bm.TUpdateBL(blog);
                _notyf.Success("Blog Başarıyla Güncellendi.");
                return RedirectToAction("BlogListByWriterr", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    _notyf.Warning("Blog Güncellenirken Bir Hata Oluştu.");
                }
            }
            return View();
        }


    }
}
