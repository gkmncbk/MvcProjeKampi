using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Concrete.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        // GET: WriterPanel
        //int writeridinfo;

        //public WriterPanelController()
        //{
        //   string p = (string)Session["WriterMail"];
        //    writeridinfo = vm.GetByWriterId(p);

        //}
        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id = wm.GetByWriterId(p);
            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MyHeading(string p)
        {

            //id = 4;
            p = (string)Session["WriterMail"];
            var writeridinfo = wm.GetByWriterId(p);

            var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuecategory;

            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {

            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string k = (string)Session["WriterMail"];
            var writeridinfo = wm.GetByWriterId(k);
            p.WriterID = writeridinfo;
            p.HeadingStatus = true;

            //HeadingValidator headingValidator = new HeadingValidator();
            //ValidationResult result = headingValidator.Validate(p);
            //if (result.IsValid)
            //{
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();

        }
        public ActionResult ChangeHeadingStatus(int id)
        {
            var HeadingValue = hm.GetByID(id);
            if (HeadingValue.HeadingStatus == true)
            {
                HeadingValue.HeadingStatus = false;
            }
            else
            {
                HeadingValue.HeadingStatus = true;
            }

            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p = 1)
        {

            var headings = hm.GetList().ToPagedList(p, 4);

            return View(headings);
        }
        [HttpPost]
        public ActionResult AllHeading(int p = 1, string aranankelime = "")
        {
            ViewBag.aranan = aranankelime;
            //ViewBag.aranan = aranankelime;
            var headings = hm.GetList().Where(x =>
                x.HeadingName.ToLower().Contains(aranankelime.ToLower()) ||
               (x.Writer.WriterName.ToLower() + " " + x.Writer.WriterSurName.ToLower()).Contains(aranankelime.ToLower()) ||
               x.Category.CategoryName.ToLower().Contains(aranankelime.ToLower())
            ).ToPagedList(p, 4);
            return View(headings);
            //return RedirectToAction("AllHeading",headings);
        }

        public ActionResult AllHeading2(int id = 1)
        {
            AllHeadingListPagition allHeadingListPagition = new AllHeadingListPagition();
            allHeadingListPagition.aktifSayfaNo = id;
            allHeadingListPagition.sayfadaBulunacakKayitAdedi = 5;

            //allHeadingListPagition.baslikListesi = hm.GetList().Where(x=>x.HeadingID>(allHeadingListPagition.aktifSayfaNo - 1)* allHeadingListPagition.sayfadaBulunacakKayitAdedi).Take(Convert.ToInt32(allHeadingListPagition.sayfadaBulunacakKayitAdedi)).ToList(); ;
            allHeadingListPagition.baslikListesi = hm.GetList().Skip(Convert.ToInt32((allHeadingListPagition.aktifSayfaNo - 1) * allHeadingListPagition.sayfadaBulunacakKayitAdedi)).Take(Convert.ToInt32(allHeadingListPagition.sayfadaBulunacakKayitAdedi)).ToList(); ;

            allHeadingListPagition.toplamKayitSayisi = hm.GetList().Count();
            double s1;
            s1 = Convert.ToDouble(allHeadingListPagition.toplamKayitSayisi / allHeadingListPagition.sayfadaBulunacakKayitAdedi);
            allHeadingListPagition.toplamSayfaSayisi = Math.Ceiling(decimal.Parse(s1.ToString()));

            if (id > allHeadingListPagition.toplamSayfaSayisi)
            {
                id = Convert.ToInt32(allHeadingListPagition.toplamSayfaSayisi);
                //return View("AllHeading2", id=1);
                return Redirect(id.ToString());
            }
            //allHeadingListPagition.toplamSayfaSayisi = Convert.ToInt32(Math.c(decimal.Parse(s1.ToString()), 0));
            return View(allHeadingListPagition);
        }
        public PartialViewResult UserDetails()
        {
            string p = (string)Session["WriterMail"];
            //string p = "admin@gmail.com";
            var writeridID = wm.GetByWriterId(p);
            var writeridinfo = wm.GetByID(writeridID);
            //ViewBag.userName=writeridinfo.
            return PartialView(writeridinfo);
        }
    }
}