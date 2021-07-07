using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class istatistikController : Controller
    {

        // GET: istatistik
        Context c = new Context();
        public ActionResult Index()
        {
           
            ViewBag.value1 = c.Categories.Count().ToString();
            ViewBag.value2 = c.Headings.Where(x => x.Category.CategoryID == 7).Count().ToString();
            ViewBag.value3 = c.Writers.Where(x => x.WriterName.Contains("a")).Count().ToString();
            ViewBag.value4 = c.Categories.Where(x => x.CategoryID == c.Headings.GroupBy(y => y.CategoryID).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.value5 = c.Categories.Where(x => x.CategoryStatus == true).Count() - c.Categories.Where(x => x.CategoryStatus == false).Count(); ;

            return View();
        }
    }
}