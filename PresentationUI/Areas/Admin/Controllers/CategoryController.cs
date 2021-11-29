using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        private readonly INotyfService _notyf;

        public CategoryController(INotyfService notyf)
        {
            _notyf = notyf;
        }



        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetListAll().ToPagedList(page, 10);
            return View(values);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus = true;
                cm.TAddBL(category);
                _notyf.Success("Kategori Başarıyla Eklendi.");
                return RedirectToAction("Index");
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CategoryEdit(Category category)
        {
            category.CategoryStatus = true;
            cm.TUpdateBL(category);
            _notyf.Success("Blog Başarıyla Güncellendi.");
            return RedirectToAction("Index");

        }

        [AllowAnonymous]
        public IActionResult CategoryDelete(int id)
        {
            var values = cm.GetByID(id);
            if (values.CategoryStatus == true)
            {
                values.CategoryStatus = false;
                _notyf.Error("Kategori Başarıyla Silindi.");
            }
            else
            {
                values.CategoryStatus = true;
                _notyf.Success("Kategori Başarıyla Eklendi.");
            }
            cm.TUpdateBL(values);
            return RedirectToAction("Index", "Category");
        }
    }
}
