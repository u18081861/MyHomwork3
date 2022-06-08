using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HW3.Models;

namespace HW3.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            string[] filepaths = Directory.GetFiles(Server.MapPath("~/Media/Images/"));
            List<FileModel> files = new List<FileModel>();

            foreach(string filepath in filepaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filepath) });
            }
            return View(files);
        }
        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }
        public ActionResult Delete(string fileName)
        {

            var DeleteThis = Server.MapPath("~/Media/Images/" + fileName);
            

            if (System.IO.File.Exists(DeleteThis))
            {
                System.IO.File.Delete(DeleteThis);
                ViewBag.Message = "Deleted";
                
            }
            return RedirectToAction("Index");




        }
    }
}