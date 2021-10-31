using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterTest()
        {
            return View();
        }

    }
}
