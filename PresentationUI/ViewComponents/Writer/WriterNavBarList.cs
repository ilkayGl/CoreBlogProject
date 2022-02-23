using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PresentationUI.ViewComponents.Writer
{
    public class WriterNavBarList : ViewComponent
    {
        private readonly IWriterService _ws;

        public WriterNavBarList(IWriterService ws)
        {
            _ws = ws;
        }

        public IViewComponentResult Invoke()
        {
            var values = _ws.GetList().Where(x => x.WriterRole == "A").ToList();
            return View(values);
        }
    }
}
