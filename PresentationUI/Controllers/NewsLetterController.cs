using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Abstract;
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
        private readonly INewsLetterService _nls;
        private readonly INotyfService _notyf;

        public NewsLetterController(INewsLetterService nls, INotyfService notyf)
        {
            _nls = nls;
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
            _nls.TAddBL(newsLetter);
            _notyf.Success("Bültene Abone Oldunuz.");
            return RedirectToAction("Index", "Blog");
        }


    }
}
