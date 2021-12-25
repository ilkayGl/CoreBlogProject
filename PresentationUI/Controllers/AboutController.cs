using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        //AboutManager am = new AboutManager(new EfAboutDal());

        private readonly Context c = new();
        private readonly IAboutService _about;

        public AboutController(IAboutService about)
        {
            _about = about;
        }


        public IActionResult Index()
        {
            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();


            var values = _about.GetList();
            return View(values);
        }

        public IActionResult SocialMediaAbout()
        {
            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();


            return View();
        }
    }
}
