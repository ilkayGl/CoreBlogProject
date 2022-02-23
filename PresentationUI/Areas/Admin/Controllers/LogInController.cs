using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PresentationUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class LogInController : Controller
    {
        private readonly Context c = new();

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer admin)
        {
            var userMail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;
            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;
            
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == admin.WriterMail && x.WriterPassword == admin.WriterPassword);

            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.WriterMail),

                };

                var useridentity = new ClaimsIdentity(claims, "Admin");


                ClaimsPrincipal principal = new ClaimsPrincipal(new[] { useridentity });

                await HttpContext.SignInAsync(principal);


                return RedirectToAction("Index", "Category");


            }
            else
            {
                return View();
            }

        }
    }
}
