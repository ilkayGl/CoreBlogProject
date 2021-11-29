using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        Context c = new Context();

        private readonly INotyfService _notyf;

        public CommentController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult PartialAddComment()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {

            int parametre = c.Comments.Select(x => x.BlogId).FirstOrDefault();

            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            //comment.BlogId = 1;
            cm.TAddBL(comment);
            _notyf.Success("Yorum Yaptınız");
            return RedirectToAction("Index", "Blog");


        }


    }
}
