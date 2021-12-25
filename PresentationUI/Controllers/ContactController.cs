using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly Context c = new();
        private readonly IContactService _cs;
        private readonly IContactLocationService _cls;
        private readonly INotyfService _notyf;

        public ContactController(IContactService cs, IContactLocationService cls, INotyfService notyf)
        {
            _cs = cs;
            _cls = cls;
            _notyf = notyf;
        }



        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();

            var contactLocationValue = _cls.GetList();
            return View(contactLocationValue);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactStatus = true;
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _cs.TAddBL(contact);
            _notyf.Success("Mesajınız Başarıyla İletildi.");
            return RedirectToAction("Index", "Contact");
        }
    }
}
