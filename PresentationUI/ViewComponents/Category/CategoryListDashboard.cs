using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        private readonly ICategoryService _cs;
        public CategoryListDashboard(ICategoryService cs)
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
