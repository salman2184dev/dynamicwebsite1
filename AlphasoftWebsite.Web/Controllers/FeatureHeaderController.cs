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

namespace AlphasoftWebsite.Web.Controllers
{
    public class FeatureHeaderController : Controller
    {
        // GET: FeatureHeader
        IFeatureHeaderManager _iFeatureHeaderManager = new FeatureHeaderManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var featureHeader = _iFeatureHeaderManager.GetAllFeatureHeader();
            return View(featureHeader);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            FeatureHeader featureHeader = new FeatureHeader();
            if (id != 0)
            {
                featureHeader = _iFeatureHeaderManager.GetFeatureHeader(id);
            }
            return View(featureHeader);
        }

        [HttpPost]
        public ActionResult AddOrEdit(FeatureHeader featureHeader, HttpPostedFileBase uploadedFile)
        {
            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "FeatureHeaderImage" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["FeatureHeaderImage"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (featureHeader.FeatureHeaderId > 0)
                    {
                        var imageName = featureHeader.FeatureHeaderImage;
                        var existingpath = ConfigurationManager.AppSettings["FeatureHeaderImage"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    featureHeader.FeatureHeaderImage = myfile;
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
            var data = _iFeatureHeaderManager.AddOrEdit(featureHeader);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFeatureHeaderManager.GetAllFeatureHeader()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var imageName = _iFeatureHeaderManager.GetFeatureHeader(id);

            var path = ConfigurationManager.AppSettings["FeatureHeaderImage"];
            var finalpath = Path.Combine(Server.MapPath(path), imageName.FeatureHeaderImage);

            if (System.IO.File.Exists(finalpath))
            {
                System.IO.File.Delete(finalpath);
            }
            var data = _iFeatureHeaderManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFeatureHeaderManager.GetAllFeatureHeader()) }, JsonRequestBehavior.AllowGet);
        }
    }
}