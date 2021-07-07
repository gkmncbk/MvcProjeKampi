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
        WriterManager vm = new WriterManager(new EfWriterDal());
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
            string p = (string)Session["WriterMail"];
            //string p = "admin@gmail.com";
            var writeridinfo = vm.GetByWriterId(p);
            ViewBag.ContactCount = cm.GetList().Count;
            ViewBag.ContactReadCount = cm.GetList().Where(x => x.ContactReadStatus == true).Count();
            ViewBag.ContactNotReadCount = cm.GetList().Where(x => x.ContactReadStatus == false).Count();

            ViewBag.MessageInboxCount = mm.GetListInbox(p,"").Count;
            ViewBag.MessageReadCount = mm.GetListInbox(p,"").Where(x => x.MessageReadStatus==true).Count();
            ViewBag.MessageNotReadCount = mm.GetListInbox(p,"").Where(x => x.MessageReadStatus == false).Count();
            ViewBag.MessageSendboxCount = mm.GetListSendbox(p,"").Count;
            ViewBag.MessageDraftboxCount = mm.GetListDraftbox(p, "").Count;

            return PartialView();
        }


    }
}