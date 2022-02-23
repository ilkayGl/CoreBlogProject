using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.ViewComponents.Category
{
    public class CategoryNavBarList : ViewComponent
    {
        private readonly ICategoryService _cs;

        public CategoryNavBarList(ICategoryService cs)
        {
            _cs = cs;
        }

        public IViewComponentResult Invoke()
        {
            var valus = _cs.GetList();
            return View(valus);
        }
    }
}
