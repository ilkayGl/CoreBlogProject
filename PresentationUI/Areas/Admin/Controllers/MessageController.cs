using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly Context c = new();
        private readonly IMessage2Service _ms;
        private readonly IWriterService _ws;
        private readonly IContactService _cts;
        private readonly INotyfService _notyf;

        public MessageController(IMessage2Service ms, IWriterService ws, IContactService cts, INotyfService notyf)
        {
            _ms = ms;
            _ws = ws;
            _cts = cts;
            _notyf = notyf;
        }



        public IActionResult ContactMessage()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;


            var value = _cts.GetList();
            return View(value);
        }

        public IActionResult InBox()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;


            var values = _ms.GetInBoxListWriter(writerID);
            return View(values);
        }


        public IActionResult SendBox()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;


            var values = _ms.GetSendBoxWriter(writerID);
            return View(values);
        }

        public IActionResult TrashBox()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;


            var values = _ms.GetTrashMessageWriter(writerID);
            return View(values);
        }


        [HttpGet]
        public IActionResult NewMessage()
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;

            List<SelectListItem> deger2 = (from x in _ws.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.WriterName + " /  " + x.WriterMail,
                                               Value = x.WriterId.ToString()

                                           }).ToList();



            ViewBag.dgr2 = deger2;


            return View();
        }


        [HttpPost]
        public IActionResult NewMessage(Message2 message2)
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;

            MessageValidator mv = new();
            ValidationResult result = mv.Validate(message2);
            if (result.IsValid)
            {
                message2.SenderId = writerID;
                message2.MessageBool = true;
                message2.MessageDate = DateTime.Parse(DateTime.Now.ToString());
                _notyf.Success("Mesaj Başarıyla Gönderildi.");
                _ms.TAddBL(message2);

                return RedirectToAction("InBox", "Message");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    _notyf.Warning("Mesaj Gönderilirken Bir Hata Oluştu.");
                }
            }

            return View();

        }


        public IActionResult MessageDetails(int id)
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;



            var value = _ms.GetByID(id);
            return View(value);
        }


        public IActionResult ContactDetails(int id)
        {
            var userMail = User.Identity.Name;

            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.writerName = writerID;

            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerRole = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterRole).FirstOrDefault();
            ViewBag.writerRole = writerRole;

            ///
            var contactMessage = c.Contacts.Count().ToString();
            ViewBag.contactMessage = contactMessage;

            var inboxMessage = _ms.GetInBoxListWriter(writerID).Count().ToString();
            ViewBag.inboxMessage = inboxMessage;

            var sendboxMessage = _ms.GetSendBoxWriter(writerID).Count().ToString();
            ViewBag.sendboxMessage = sendboxMessage;

            var trashboxMessage = _ms.GetTrashMessageWriter(writerID).Count().ToString();
            ViewBag.trashboxMessage = trashboxMessage;



            var value = _cts.GetByID(id);
            return View(value);
        }


        public IActionResult MessageDelete(int id)
        {
            var values = _ms.GetByID(id);
            if (values.MessageBool == true)
            {
                values.MessageBool = false;
                _notyf.Error("Mesaj Başarıyla Silindi.");
            }
            else
            {
                values.MessageBool = true;
                _notyf.Success("Mesaj Başarıyla Eklendi.");
            }
            _ms.TUpdateBL(values);
            return RedirectToAction("InBox", "Message");
        }


        public IActionResult MessageRemove(int id)
        {
            var values = _ms.GetByID(id);
            _notyf.Error("Mesaj Kalıcı Olarak Silindi.");
            _ms.TDeleteBL(values);
            return RedirectToAction("TrashBox", "Message");
        }

        public IActionResult ContactDelete(int id)
        {
            var contactDelete = _cts.GetByID(id);
            _notyf.Error("Mesaj Başarıyla Silindi.");
            _cts.TDeleteBL(contactDelete);
            return RedirectToAction("ContactMessage", "Message");


        }
    }
}
