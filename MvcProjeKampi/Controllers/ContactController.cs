using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            if (contactvalues.ContactReadStatus == false)
            {
                contactvalues.ContactReadStatus = true;
                cm.ContactUpdate(contactvalues);
            }
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            ViewBag.ContactCount = cm.GetList().Count;
            ViewBag.ContactReadCount = cm.GetList().Where(x => x.ContactReadStatus == true).Count();
            ViewBag.ContactNotReadCount = cm.GetList().Where(x => x.ContactReadStatus == false).Count();

            ViewBag.MessageInboxCount = mm.GetListInbox().Count;
            ViewBag.MessageReadCount = mm.GetListInbox().Where(x => x.MessageReadStatus==true).Count();
            ViewBag.MessageNotReadCount = mm.GetListInbox().Where(x => x.MessageReadStatus == false).Count();
            ViewBag.MessageSendboxCount = mm.GetListSendbox().Count;
            ViewBag.MessageDraftboxCount = mm.GetListDraftbox().Count;

            return PartialView();
        }
    }
}