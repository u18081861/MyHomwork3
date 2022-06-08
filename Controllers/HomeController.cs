using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using HW3.Models;

namespace HW3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            
            return View();
        }


        [HttpPost]

        public ActionResult Index(FormCollection frm, HttpPostedFileBase file)
        {


            try
            {
                var type = frm["Type"].ToString();

                if (type.Equals("doc"))
                {
                    if (file.ContentLength > 0)
                    {
                        string filename = Path.GetFileName(file.FileName);
                        string filepath = Path.Combine(Server.MapPath("~/Media/Documents"), filename);
                        file.SaveAs(filepath);
                    }

                    ViewBag.Message = "You submitted a Document.";

                    return View();
                }


                if (type.Equals("img"))
                {

                    

                        if (file.ContentLength > 0)
                        {
                            string filename = Path.GetFileName(file.FileName);
                            string filepath = Path.Combine(Server.MapPath("~/Media/Images"), filename);
                            file.SaveAs(filepath);
                        }
                        ViewBag.Message = "You submitted an Image.";

                        return View();   

                }
              
                if (type.Equals("vid"))
                {

                    if (file.ContentLength > 0)
                    {
                        string filename = Path.GetFileName(file.FileName);
                        string filepath = Path.Combine(Server.MapPath("~/Media/Videos"), filename);
                        file.SaveAs(filepath);
                    }
                }
                ViewBag.Message = "You submitted an Video .";
                return View();
            }

            catch
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
            }

        }

        
        public ActionResult About()
        {
            return View();
        }
       
    }
}