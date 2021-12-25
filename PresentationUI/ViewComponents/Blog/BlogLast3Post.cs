using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        private readonly IBlogService _bs;

        public BlogLast3Post(IBlogService bs)
        {
            _bs = bs;
        }


        public IViewComponentResult Invoke()
        {
            var values = _bs.GetLast3Blog();
            return View(values);
        }
    }
}
