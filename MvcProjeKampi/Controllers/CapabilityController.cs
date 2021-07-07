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
    public class CapabilityController : Controller
    {
        CapabilityManager cm = new CapabilityManager(new EfCapabilityDal());
        // GET: Capability
        public ActionResult Index()
        {
            var capabilityvalues = cm.GetList();
            return View(capabilityvalues);
        }
        [HttpGet]
        public ActionResult AddCapability()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCapability(Capability p)
        {
            if (string.IsNullOrEmpty(p.CapabilityName) || p.CapabilityLevel<1 ||p.CapabilityLevel>100)
            {
               return View(p);
            }
            else
            { 
                p.CapabilityStatus = true;
                cm.CapabilityAdd(p);
                return RedirectToAction("Index");
               
            }

        }
        public ActionResult ActionCapability()
        {
            var capabilityvalues = cm.GetList();
            return View(capabilityvalues);
        }
        [HttpGet]
        public ActionResult EditCapability(int id)
        {
            var capabilityvalue = cm.GetByID(id);
            return View(capabilityvalue);
        }
        [HttpPost]
        public ActionResult EditCapability(Capability p)
        {
            if (string.IsNullOrEmpty(p.CapabilityName) || p.CapabilityLevel < 1 || p.CapabilityLevel > 100)
            {
                return View(p);
            }
            else
            {
                cm.CapabilityUpdate(p);
                return RedirectToAction("Index");

            }
        }


        public ActionResult DeleteCapability(int id)
        {
            var capabilityvalue = cm.GetByID(id);
            cm.CapabilityDelete(capabilityvalue);
            return RedirectToAction("Index");
           
        }
    }
}