using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using X.PagedList;
namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly Context c = new();
        private readonly ICategoryService _cs;
        private readonly IMessage2Service _ms;
        private readonly INotyfService _notyf;

        public CategoryController(ICategoryService cs, IMessage2Service ms, INotyfService notyf)
        {
            _cs = cs;
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


            var values = _cs.GetListAll().ToPagedList(page, 10);
            return View(values);
        }


        [HttpGet]
        public IActionResult CategoryAdd()
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

            return View();
        }


        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus = true;
                _cs.TAddBL(category);
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


        [HttpGet]
        public IActionResult CategoryEdit(int id)
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

            var values = _cs.GetByID(id);
            return View(values);
        }


        [HttpPost]
        public IActionResult CategoryEdit(Category category)
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

            category.CategoryStatus = true;
            _cs.TUpdateBL(category);
            _notyf.Success("Blog Başarıyla Güncellendi.");
            return RedirectToAction("Index");

        }


        public IActionResult CategoryDelete(int id)
        {
            var values = _cs.GetByID(id);
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
            _cs.TUpdateBL(values);
            return RedirectToAction("Index", "Category");
        }
    }
}
