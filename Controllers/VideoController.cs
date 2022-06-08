using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using  HW3.Models;

namespace HW3.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            string[] filepaths = Directory.GetFiles(Server.MapPath("~/Media/Videos/"));
            List<FileModel> files = new List<FileModel>();

            foreach (string filepath in filepaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filepath) });
            }
            return View(files);
           
        }
        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }
        public ActionResult Delete(string fileName)
        {
            var DeleteThis = Server.MapPath("~/Media/Videos/" + fileName);


            if (System.IO.File.Exists(DeleteThis))
            {
                System.IO.File.Delete(DeleteThis);
                ViewBag.Message = "Deleted";

            }
            return RedirectToAction("Index");
        }
    }
}