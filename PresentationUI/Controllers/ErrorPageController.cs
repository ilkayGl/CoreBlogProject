using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Page404(int code)
        {
            ViewBag.Code = code;
            return View();
        }
    }
}
