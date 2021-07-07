using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager vm = new WriterManager(new EfWriterDal());
        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            //int id =2;            
            string p = (string)Session["WriterMail"];
            var Writeridinfo = vm.GetByWriterId(p);
            var contentvalues = cm.GetListByWriter(Writeridinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail= (string)Session["WriterMail"];
            var writeridinfo = vm.GetByWriterId(mail);
            p.ContentDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.ContentSatatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}