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
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());

        private readonly INotyfService _notyf;

        public CommentController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PartialAddComment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogId = 1;
            cm.CommentAddBL(comment);
            _notyf.Success("Yorum Yaptınız");
            return RedirectToAction("BlogReadAll", "Blog", new { id = comment.BlogId });
        }

    }
}
