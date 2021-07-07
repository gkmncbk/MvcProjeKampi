using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }

        ChartManager cm = new ChartManager(new ChartDal());

        public ActionResult Chart1()
        {
            return Json(cm.GetList1(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Chart2()
        {
            return Json(cm.GetList2(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult Chart3()
        {
            return Json(cm.GetList3(), JsonRequestBehavior.AllowGet);
        }




    }
}