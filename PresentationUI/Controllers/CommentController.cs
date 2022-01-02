using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
            if (comment.CommentContent == null || comment.CommentUserName == null || comment.CommentTitle == null)
            {
                _notyf.Warning("Yorum Alanını Boş Bırakamazsınız.");
                //_cs.TDeleteBL(comment);
                return Json(true);

            }

            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;

            _cs.TAddBL(comment);
            _notyf.Success("Yorum Yaptınız");

            return Json(true);



        }


    }
}
