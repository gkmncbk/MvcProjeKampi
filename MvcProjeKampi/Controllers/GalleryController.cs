using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {

            var files = ifm.GetList();
            return View(files);
        }


        [HttpGet]
        public ActionResult ImageUpload()
        {
            return View();
        }



        [HttpPost]
        public ActionResult ImageUpload(HttpPostedFileBase uploadfile)
        {


            if (uploadfile != null && uploadfile.ContentLength > 0)
            {
                string imagePath = "/AdminLTE-3.0.4/images/";
                ////Guid.NewGuid().ToString() + "_" +
                string imageName = Path.GetFileName(uploadfile.FileName);
                var ImageNameWithoutExtension = Path.GetFileNameWithoutExtension(uploadfile.FileName);
                string filePath = Path.Combine(Server.MapPath(imagePath), imageName);
                uploadfile.SaveAs(filePath);

                ImageFile imageFile = new ImageFile();
                imageFile.ImageName = ImageNameWithoutExtension;
                imageFile.ImagePath = imagePath + imageName;
                ifm.ImageAdd(imageFile);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteImage(int id)
        {
            var imagefilevalue = ifm.GetByID(id);
            ifm.ImageDelete(imagefilevalue);


            if (System.IO.File.Exists(Server.MapPath(imagefilevalue.ImagePath)))
            {
                System.IO.File.Delete(Server.MapPath(imagefilevalue.ImagePath));
            }
            return RedirectToAction("Index");
        }


    }
}