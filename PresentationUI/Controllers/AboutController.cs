using BusinessLayer.Concrete;
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
        AboutManager am = new AboutManager(new EfAboutDal());

        public IActionResult Index()
        {
            var values = am.GetList();
            return View(values);
        }

        public IActionResult SocialMediaAbout()
        {
           
            return View();
        }
    }
}
