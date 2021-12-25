using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly Context c = new();
        private readonly WriterValidator writerValidator = new();
        private readonly IWriterService _ws;

        public RegisterController(IWriterService ws)
        {
            _ws = ws;
        }



        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();

            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer writer)
        {

            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterStatus = true;
                _ws.TAddBL(writer);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        //public List<SelectListItem> GetCityList()
        //{
        //    List<SelectListItem> cities = (from x in GetCityArray()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x,
        //                                       Value = x
        //                                   }).ToList();
        //    return cities;
        //}
        //public List<string> GetCityArray()
        //{
        //    String[] CitiesArray = new String[] { "Adana", "Adıyaman", "Afyon", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Bartın", "Batman", "Balıkesir", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İçel", "İstanbul", "İzmir", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Şırnak", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
        //    return new List<string>(CitiesArray);
        //}
    }
}
