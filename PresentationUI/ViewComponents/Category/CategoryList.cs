using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryService _cs;
        public CategoryList(ICategoryService cs)
        {
            _cs = cs;
        }


        public IViewComponentResult Invoke()
        {
            var values = _cs.GetList();
            return View(values);
        }
    }
}
