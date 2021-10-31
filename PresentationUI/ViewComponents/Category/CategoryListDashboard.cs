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
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
