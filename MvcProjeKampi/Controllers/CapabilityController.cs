using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CapabilityController : Controller
    {
        CapabilityManager cm = new CapabilityManager(new EfCapabilityDal());
        // GET: Capability
        public ActionResult Index()
        {
            var capabilityvalues = cm.GetList();
            return View(capabilityvalues);
        }
    }
}