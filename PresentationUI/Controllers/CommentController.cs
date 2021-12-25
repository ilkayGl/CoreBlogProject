using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Abstract;
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
        private readonly ICommentService _cs;
        private readonly INotyfService _notyf;

        public CommentController(ICommentService cs, INotyfService notyf)
        {
            _cs = cs;
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

            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;

            _cs.TAddBL(comment);
            _notyf.Success("Yorum Yaptınız");
            //return RedirectToAction("Index", "Blog");
            return Json(true);


        }


    }
}
