using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        // GET: Message
        [Authorize]
        public ActionResult Inbox()
        {
            var messagelist = mm.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var messagelist = mm.GetListSendbox();
            return View(messagelist);
        }
        public ActionResult Draftbox()
        {
            var messagelist = mm.GetListDraftbox();
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            
            var values = mm.GetByID(id);
            if (values.MessageReadStatus == false)
            {
                values.MessageReadStatus = true;
                mm.MessageUpdate(values);
            }

            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetDraftboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message p, string btn)
        {            
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = "admin@gmail.com";
                p.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString());
                if (btn == "Send")
                {
                    p.MessageDraftsStatus = false;
                    mm.MessageAdd(p);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    p.MessageDraftsStatus = true;
                    mm.MessageAdd(p);
                    return RedirectToAction("Draftbox");
                }
        
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
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DraftMessage(Message p, string btn)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = "admin@gmail.com";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                if (btn == "Send")
                {
                    p.MessageDraftsStatus = false;
                    mm.MessageUpdate(p);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    p.MessageDraftsStatus = true;
                    mm.MessageUpdate(p);
                    return RedirectToAction("Draftbox");
                }

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
        public string StripHTML(string input=null)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

    }
}