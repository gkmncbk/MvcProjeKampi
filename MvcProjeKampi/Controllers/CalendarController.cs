using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CalendarController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCalendarEvents()
        {
            List<CalendarEvent> eventItems = new List<CalendarEvent>();
            
            var headingvalues = hm.GetList();
           

            foreach (var value in headingvalues)
            {
                CalendarEvent item = new CalendarEvent();
                string a = "*" + value.HeadingName;
                item.title = a;
                string h1 = value.HeadingDate.Year.ToString() + "." + (value.HeadingDate.Month).ToString() + "." + (value.HeadingDate.Day).ToString();
                string h2 = value.HeadingDate.Year.ToString() + "." + (value.HeadingDate.Month).ToString() + "." + (value.HeadingDate.Day ).ToString();
                item.start = h1;
                item.end = h2;
                item.allDay = true;
                item.color = "white";
                eventItems.Add(item);
            }

            return Json(eventItems, JsonRequestBehavior.AllowGet);
        }

    }
}