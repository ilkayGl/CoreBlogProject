using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly Context c = new();
        private readonly IWriterService _ws;

        public WriterAboutOnDashboard(IWriterService ws)
        {
            _ws = ws;
        }


        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var values = _ws.GetWriterById(writerID);
            return View(values);
        }
    }
}
