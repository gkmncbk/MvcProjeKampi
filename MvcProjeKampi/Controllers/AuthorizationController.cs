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
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        RoleManager rm = new RoleManager(new EfRoleDal());
        //LoginManager lm = new LoginManager();
        // GET: Authorization
        public ActionResult Index()
        {
            var adminvalues = adm.GetListAdmin();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueAdminRole = (from c in rm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleID.ToString()

                                                   }).ToList();

            ViewBag.valueAdminRole = valueAdminRole;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.AdminAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {

            List<SelectListItem> valueAdminRole = (from c in rm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleID.ToString()

                                                   }).ToList();

            ViewBag.valueAdminRole = valueAdminRole;
            var adminvalue = adm.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adm.AdminUpdate(p);
            //string s = User.Identity ;
            //Session["Role"] = p.Role.RoleName;
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var result = adm.GetByID(id);
            if (result.AdminStatus== true)
            {
                result.AdminStatus = false;
            }
            else
            {
                result.AdminStatus = true;
            }
            adm.AdminUpdate(result);
            return RedirectToAction("Index");
        }
    }
}