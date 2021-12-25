using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _cs;

        public CategoryController(ICategoryService cs)
        {
            _cs = cs;
        }



        public IActionResult Index()
        {
            var values = _cs.GetList();
            return View(values);
        }

    }
}
