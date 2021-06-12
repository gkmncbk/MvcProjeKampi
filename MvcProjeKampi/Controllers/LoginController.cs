using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        LoginManager lm = new LoginManager();
        AdminManager adm = new AdminManager(new EfAdminDal());

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {           
            return View();
        }   

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var userHash = lm.PasswordHash(p.AdminUserName);
            var passwordHash = lm.PasswordHash(p.AdminPassword);
            var adminuserinfo = adm.GetByAdmin(userHash, passwordHash);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı yada şifre hatalı");
                return View();
                //ViewBag.Msg2 = "Hata Var";
                //return RedirectToAction("Index", new { s = ViewBag.Msg2 });
                //return RedirectToAction("Index");
            }

        }

    }
}