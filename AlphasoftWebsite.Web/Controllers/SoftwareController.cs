using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.BLL.Manager;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;
using Newtonsoft.Json;

namespace AlphasoftWebsite.Web.Controllers
{
    public class SoftwareController : Controller
    {
        // GET: Software
        ISoftwareManager _iSoftwareManager = new SoftwareManager();
       
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            var software = _iSoftwareManager.GetAllSoftware();
            return View(software);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Software software = new Software();
            if (id != 0)
            {
                software = _iSoftwareManager.GetASoftware(id);
            }
            return View(software);
        }

        //[HttpPost]
        //public ActionResult AddOrEdit(Software software, HttpPostedFileBase uploadedFile)
        //{
        //    if (uploadedFile != null)
        //    {
        //        string fileName = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
        //        string extension = Path.GetExtension(uploadedFile.FileName);
        //        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //        software.SoftwareImage = "~/Image/Software/" + fileName;
        //        uploadedFile.SaveAs(Path.Combine(Server.MapPath("~/Image/Software/"), fileName));

        //    }
        //    var data = _iSoftwareManager.AddOrEdit(software);
        //    return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iSoftwareManager.GetAllSoftware()) }, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult AddOrEdit(Software software, HttpPostedFileBase uploadedFile)
        {

            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "SoftwareImage" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["SoftwareImage"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (software.SoftwareId > 0)
                    {
                        var imageName = software.SoftwareImage;
                        var existingpath = ConfigurationManager.AppSettings["SoftwareImage"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    software.SoftwareImage = myfile;
                    uploadedFile.SaveAs(finalpath);
                }
                else
                {
                    Message message = new Message();
                    message.ReturnMessage = "Choose only Image File!";
                    message.MessageType = MessageTypes.Information;
                }
            }
            else
            {
                Message message = new Message();
                message.ReturnMessage = "Select an Image!";
                message.MessageType = MessageTypes.Information;
            }
            var data = _iSoftwareManager.AddOrEdit(software);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iSoftwareManager.GetAllSoftware()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var imageName = _iSoftwareManager.GetASoftware(id);

            var path = ConfigurationManager.AppSettings["SoftwareImage"];
            var finalpath = Path.Combine(Server.MapPath(path), imageName.SoftwareImage);

            if (System.IO.File.Exists(finalpath))
            {
                System.IO.File.Delete(finalpath);
            }
            var data = _iSoftwareManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iSoftwareManager.GetAllSoftware()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetASoftwareById(int softwareId)
        {
            var software = _iSoftwareManager.GetASoftware(softwareId);
            var data = JsonConvert.SerializeObject(software, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}