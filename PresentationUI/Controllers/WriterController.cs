using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;


namespace PresentationUI.Controllers
{
    //[Authorize(Policy = "A")]
    public class WriterController : Controller
    {
        private readonly Context c = new();
        private readonly IWriterService _ws;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;
        private readonly IWebHostEnvironment _hostEnvironment;

        public WriterController(IWriterService ws, IMapper mapper, INotyfService notyf, IWebHostEnvironment hostEnvironment)
        {
            _ws = ws;
            _mapper = mapper;
            _notyf = notyf;
            _hostEnvironment = hostEnvironment;
        }


        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerID = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ViewBag.logo = c.LogoTitles.Select(x => x.Logo).FirstOrDefault();
            ViewBag.logoTitle = c.LogoTitles.Select(x => x.Title).FirstOrDefault();


            var writerValues = _ws.GetByID(writerID);
            return View(writerValues);
        }


        [HttpPost]
        public IActionResult WriterEditProfile(Writer w, AddProfileImageDTO p)
        {
            var dosyaYolu = Path.Combine(_hostEnvironment.WebRootPath, "WriterImageFiles"); //birleştir
            if (!Directory.Exists(dosyaYolu)) //yoksa
            {
                Directory.CreateDirectory(dosyaYolu); //oluştur
            }
            var tamDosyaAdi = Path.Combine(dosyaYolu, p.WriterImage.FileName); //wwwroote içine  dosya yolu tanımlıyor
                                                                               //file upload
            using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
            {
                p.WriterImage.CopyTo(dosyaAkisi);
            }//using ekleme amacımız Gc beklemeden kaynağı yok etmesidir.

            w.WriterImage = p.WriterImage.FileName;

            w.WriterId = p.WriterId;
            w.WriterName = p.WriterName;
            w.WriterMail = p.WriterMail;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            w.WriterRole = w.WriterRole;
            w.WriterTitle = w.WriterTitle;
            _ws.TUpdateBL(w);

            _notyf.Success("Blog Başarıyla Eklendi.");

            return RedirectToAction("Index", "Dashboard");

        }



    }
}
