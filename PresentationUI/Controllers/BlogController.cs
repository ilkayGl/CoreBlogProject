using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        private readonly INotyfService _notyf;

        public BlogController(INotyfService notyf)
        {
            _notyf = notyf;
        }


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


        public IActionResult BlogListByWriterr()
        {
            var values = bm.GetListWithCategoryByWriterBm(1);
            return View(values);
        }


        [HttpGet]
        public IActionResult BlogAdd()
        {
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
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
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
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.WriterId = 1;
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
