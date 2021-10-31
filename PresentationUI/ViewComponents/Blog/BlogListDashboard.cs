using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogDal());

        public IViewComponentResult Invoke()
        {
            var values = bm.GetBlogListWithCategory().OrderByDescending(x=>x.BlogCreateDate).Take(10).ToList(); 
            return View(values);
        }
    }
}
