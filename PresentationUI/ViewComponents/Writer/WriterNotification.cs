using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        private readonly INotificationService _ns;
        public WriterNotification(INotificationService ns)
        {
            _ns = ns;
        }

        public IViewComponentResult Invoke()
        {
            var values = _ns.GetByDesTake3List();
            return View(values);
        }
    }
}
