using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [AllowAnonymous]
        public ActionResult Test3()
        {
            return View();
        }
        public ActionResult SweetAlert()
        {
            return View();
        }
    }
}