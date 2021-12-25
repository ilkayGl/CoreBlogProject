using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace PresentationUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly Context c = new();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);

            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,writer.WriterMail),
                    //new Claim(ClaimTypes.Role,"A"),

                };

                var useridentity = new ClaimsIdentity(claims, "Blog");


                ClaimsPrincipal principal = new ClaimsPrincipal(new[] { useridentity });

                await HttpContext.SignInAsync(principal);


                return RedirectToAction("Index", "Dashboard");


            }
            else
            {
                return View();
            }

        }



        public async Task GoogleLogin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("Index", "Dashboard")
            });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });
            return Json(claims);
        }


        public async Task<IActionResult> GoogleLogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
