using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager nlm = new NewsLetterManager(new EfNewsLetterDal());

        private readonly INotyfService _notyf;

        public NewsLetterController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            nlm.NewsLatterAddBL(newsLetter);
            _notyf.Success("Bültene Abone Oldunuz.");
            return RedirectToAction("Index", "Blog");
        }


    }
}
