using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
//using EntityLayer.Concrete;
using EntityLayer.Concrete.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        LoginManager lm = new LoginManager();
        AdminManager adm = new AdminManager(new EfAdminDal());
        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            //if (Session["WriterMail"]==null)
            //{
            //    return RedirectToAction("MyContent", "WriterPanelContent");
            //}
            //else
            //{
            return View();
            //}

        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            //var userHash = lm.PasswordHash(p.AdminUserName);
            var userHash = lm.Encrypt(p.AdminUserName);


            var passwordHash = lm.PasswordHash(p.AdminPassword);

            var adminuserinfo = adm.GetByAdmin(userHash, passwordHash);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;

                if (adminuserinfo.Role.RoleName == "B")
                {
                    return RedirectToAction("Index", "AdminCategory");
                }
                else
                {
                    return RedirectToAction("Index", "Heading");
                }
                //}


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
        [HttpGet]
        public ActionResult WriterLogin()
        {

            if (Session["WriterMail"] != null)
            {
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //var userHash = lm.PasswordHash(p.WriterMail);
            //var passwordHash = lm.PasswordHash(p.WriterPassword);

            //string captcha = Request.Form["g-recaptcha-response"];
            bool result = lm.ReCaptcha(Request.Form["g-recaptcha-response"]);

            var userHash = p.WriterMail;
            var passwordHash = p.WriterPassword;

            //var writeruserinfo = wm.GetByWriter(userHash, passwordHash);
            var writeruserinfo = wm.GetWriter(userHash, passwordHash);           
            if (writeruserinfo != null && result)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                if (!result)
                {
                    ViewBag.loginHata2 = "* Robot doğrulaması hatalı. Lütfen tekrar deneyin.";
                }
                if (writeruserinfo == null)
                {
                    ViewBag.loginHata1 = "* Kullanıcı adı yada şifre hatalı";
                }

                return View();

            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();


            return RedirectToAction("Headings", "Default");
        }




    }
}