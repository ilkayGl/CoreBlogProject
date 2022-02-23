using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        private readonly IBlogService _bs;

        public BlogLast3Post(IBlogService bs)
        {
            _bs = bs;
        }


        public IViewComponentResult Invoke()
        {
            var values = _bs.GetLast3Blog();
            return View(values);
        }
    }
}
