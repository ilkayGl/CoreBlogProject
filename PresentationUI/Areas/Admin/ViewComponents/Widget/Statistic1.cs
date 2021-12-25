using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PresentationUI.Areas.Admin.ViewComponents.Widget
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new(new EfBlogDal());
        Context c = new();

        public IViewComponentResult Invoke()
        {
            ViewBag.totalBlog = bm.GetList().Count();
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
