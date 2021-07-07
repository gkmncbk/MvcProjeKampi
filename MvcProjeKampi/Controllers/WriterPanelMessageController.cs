using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        WriterManager vm = new WriterManager(new EfWriterDal());
        // GET: WriterPanelMessage
        public ActionResult Inbox(string k="")
        {
            string p = (string)Session["WriterMail"];
            var writeridinfo = vm.GetByWriterId(p);
            var messagelist = mm.GetListInbox(p,k);
            return View(messagelist);
        }
        public ActionResult Sendbox(string k = "")
        {
            string p = (string)Session["WriterMail"];
            var writeridinfo = vm.GetByWriterId(p);
            var messagelist = mm.GetListSendbox(p, k);
            return View(messagelist);
        }
        public ActionResult Draftbox(string k = "")
        {
            string p = (string)Session["WriterMail"];
            var writeridinfo = vm.GetByWriterId(p);
            var messagelist = mm.GetListDraftbox(p, k);
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
        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];
            var writeridinfo = vm.GetByWriterId(p);
            ViewBag.MessageInboxCount = mm.GetListInbox(p,"").Count;
            ViewBag.MessageReadCount = mm.GetListInbox(p,"").Where(x => x.MessageReadStatus == true).Count();
            ViewBag.MessageNotReadCount = mm.GetListInbox(p,"").Where(x => x.MessageReadStatus == false).Count();
            ViewBag.MessageSendboxCount = mm.GetListSendbox(p,"").Count;
            ViewBag.MessageDraftboxCount = mm.GetListDraftbox(p,"").Count;

            return PartialView();
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
                
                p.SenderMail = (string)Session["WriterMail"];
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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
                p.SenderMail = (string)Session["WriterMail"];
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

    }
}