using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        private readonly ICommentService _cs;
        public CommentListByBlog(ICommentService cs)
        {
            _cs = cs;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _cs.GetFilterList(id);
            return View(values);
        }
    }
}
