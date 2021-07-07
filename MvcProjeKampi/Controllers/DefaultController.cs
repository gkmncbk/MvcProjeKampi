using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Default
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }
        public PartialViewResult Index(int id = 0)
        {

            if (id == 0 && cm.GetList("").Count()>0)
            {

                Random random = new Random();
                int y = random.Next(1, cm.GetList("").Count());
                id = cm.GetList("").Skip(y).FirstOrDefault().HeadingID;
            }
            var contentList = cm.GetListByHeadingID(id);
            return PartialView(contentList);
        }
    }
}