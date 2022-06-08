using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW3.Models;

namespace HW3.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            string[] filepaths = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));
            List<FileModel> files = new List<FileModel>();

            foreach (string filepath in filepaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filepath) });
            }
            return View(files);


        }
        public FileResult DownloadFile(string fileName)
        {
            var DownloadThis = Server.MapPath("~/Media/Documents/") + fileName;
           
                byte[] bytes = System.IO.File.ReadAllBytes(DownloadThis);
                return File(bytes, "application/octet-stream", fileName);
            
           

        }

        public ActionResult Delete(string fileName)
        {
            var DeleteThis = Server.MapPath("~/Media/Documents/" + fileName);


            if (System.IO.File.Exists(DeleteThis))
            {
                System.IO.File.Delete(DeleteThis);
                ViewBag.Message = "Deleted";

            }
            return RedirectToAction("Index");
        }
    }
}
    
