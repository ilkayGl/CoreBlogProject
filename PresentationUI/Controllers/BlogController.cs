using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using X.PagedList;

namespace PresentationUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly Context c = new();
        private readonly IBlogService _bs;
        private readonly ICategoryService _cs;
        private readonly INotyfService _notyf;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BlogController(IBlogService bs, ICategoryService cs, INotyfService notyf, IWebHostEnvironment hostEnvironment)
        {
            _bs = bs;
            _cs = cs;
            _notyf = notyf;
            _hostEnvironment = hostEnvironment;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(int? Sayfa, string Blogsearch)
        {

            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();

            //yorum sayısını getirme-güncellenecek
            var yrm = c.Comments.Select(u => u.CommentId).FirstOrDefault();
            var value = c.Blogs.Where(x => x.BlogId == yrm).Count().ToString();
            ViewBag.comment = value;


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

            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();

            ViewBag.i = id; // todo =* ViewComment= BlogId ye göre yorum getirmek için id yi çekiyoruz BlogReadAll.cshtl Vc id olarak atıyoruz
            var values = _bs.GetBlogIdListWriter(id);
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

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();



            var values = _bs.GetListWithCategoryByWriter(writerID);
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

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();


            List<SelectListItem> deger1 = (from x in _cs.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()

                                           }).ToList();



            ViewBag.dgr1 = deger1;

            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd([Bind("BlogId", "BlogTitle", "BlogContent", "BlogThumbnailImage", "BlogImage", "Image", "BlogCreateDate", "BlogStatus", "CategoryId", "WriterId")] Blog blog)
        {

            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;


            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();


            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blog);
            if (result.IsValid)
            {
                var dosyaYolu = Path.Combine(_hostEnvironment.WebRootPath, "BlogImageFiles"); //birleştir
                if (!Directory.Exists(dosyaYolu)) //yoksa
                {
                    Directory.CreateDirectory(dosyaYolu); //oluştur
                }
                var tamDosyaAdi = Path.Combine(dosyaYolu, blog.Image.FileName); //wwwroote içine img adında dosya yolu tanımlıyor
                                                                                //file upload
                using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
                {
                    blog.Image.CopyTo(dosyaAkisi);
                }//using ekleme amacımız Gc beklemeden kaynağı yok etmesidir.

                blog.BlogImage = blog.Image.FileName;

                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerID;
                _bs.TAddBL(blog);
                _notyf.Success("Blog Başarıyla Eklendi.");
                return RedirectToAction("BlogListByWriterr", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    _notyf.Warning("Blog Eklenirken Bir Hata Oluştu");
                }
            }
            return View();

        }


        public IActionResult BlogDelete(int id)
        {
            var values = _bs.GetByID(id);
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
            _bs.TUpdateBL(values);
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

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;


            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();


            var blogValue = _bs.GetByID(id);
            List<SelectListItem> deger1 = (from x in _cs.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()

                                           }).ToList();



            ViewBag.dgr1 = deger1;
            return View(blogValue);
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog b)
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(b);
            if (result.IsValid)
            {
                var dosyaYolu = Path.Combine(_hostEnvironment.WebRootPath, "BlogImageFiles");
                if (!Directory.Exists(dosyaYolu))
                {
                    Directory.CreateDirectory(dosyaYolu);
                }
                var tamDosyaAdi = Path.Combine(dosyaYolu, b.Image.FileName);
                using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
                {
                    b.Image.CopyTo(dosyaAkisi);
                }

                b.BlogImage = b.Image.FileName;


                b.BlogStatus = true;
                b.WriterId = writerID;
                _bs.TUpdateBL(b);
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



        [AllowAnonymous]
        public IActionResult CategoryDetail(int? Sayfa, int id)
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            /////

            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();

            //yorum sayısını getirme-güncellenecek
            var yrm = c.Comments.Select(u => u.CommentId).FirstOrDefault();
            var value = c.Blogs.Where(x => x.BlogId == yrm).Count().ToString();
            ViewBag.comment = value;



            var pageNumber = Sayfa ?? 1;
            int pagaSize = 9;

            var valueCategory = _bs.GetBlogListWithCategory().Where(x => x.Category.CategoryId == id).ToList();
            return View(valueCategory.ToPagedList(pageNumber, pagaSize));
        }

    }
}
