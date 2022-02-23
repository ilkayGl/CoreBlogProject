using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            var notifications = _ns.GetList().Count().ToString();
            ViewBag.notifications = notifications;


            var values = _ns.GetByDesTake3List();
            return View(values);
        }
    }
}
