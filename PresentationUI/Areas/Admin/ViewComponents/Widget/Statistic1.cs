using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace PresentationUI.Areas.Admin.ViewComponents.Widget
{
    public class Statistic1 : ViewComponent
    {
        private readonly Context c = new();
        private readonly IBlogService _bs;

        public Statistic1(IBlogService bs)
        {
            _bs = bs;
        }

       

        public IViewComponentResult Invoke()
        {
            ViewBag.totalBlog = _bs.GetList().Count;
            ViewBag.contactMessage = c.Contacts.Count();
            ViewBag.totalComment = c.Comments.Count();

            //WreatherAPI
            string api = "7cc153d134e2a6ebdbf706b53f65de19";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Tekirdağ&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.wreather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.wreather2 = document.Descendants("weather").ElementAt(0).Attribute("value").Value;


            return View();
        }
    }
}
