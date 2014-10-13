using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropZoneFileUpload.Models;

namespace DropZoneFileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.View(actionName).ExecuteResult(this.ControllerContext);
            //base.HandleUnknownAction(actionName);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
                //Save file content goes here
                fName = file.FileName;
                if (file != null && file.ContentLength > 0)
                {
                   
                    var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallImages", Server.MapPath(@"\")));

                    string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                    var fileName1 = Path.GetFileName(file.FileName);
                  

                    bool isExists = System.IO.Directory.Exists(pathString);

                    if (!isExists)
                        System.IO.Directory.CreateDirectory(pathString);

                    var path = string.Format("{0}\\{1}", pathString, file.FileName);
                    file.SaveAs(path);

                }

            }

            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
        }


        public ActionResult DisplayImages()
        {
            return View();
        }

        public ActionResult GetAttachments()
        {
            //Get the images list from repository
            var attachmentsList =  new List<AttachmentsModel>
            {
                new AttachmentsModel {AttachmentID = 1, FileName = "/images/wallimages/dropzonelayout.png", Path = "/images/wallimages/dropzonelayout.png"},
                new AttachmentsModel {AttachmentID = 1, FileName = "/images/wallimages/imageslider-3.png", Path = "/images/wallimages/imageslider-3.png"}
            }.ToList();

            return Json(new { Data = attachmentsList }, JsonRequestBehavior.AllowGet); 
        }
    }
}