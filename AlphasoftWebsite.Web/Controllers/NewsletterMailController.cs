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
    public class NewsletterMailController : Controller
    {
        // GET: NewsletterMail
        INewsletterMailManager _iNewsletterMailManager = new NewsletterMailManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var newsletterMail = _iNewsletterMailManager.GetAllNewsletterMail();
            return View(newsletterMail);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            NewsletterMail newsletterMail = new NewsletterMail();
            if (id != 0)
            {
                newsletterMail = _iNewsletterMailManager.GetANewsletterMail(id);
            }
            return View(newsletterMail);
        }

        [HttpPost]
        public ActionResult AddOrEdit(NewsletterMail newsletterMail, HttpPostedFileBase uploadedFile)
        {

            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "AttachFile" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["AttachFile"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (newsletterMail.NewsletterMailId > 0)
                    {
                        var imageName = newsletterMail.AttachFile;
                        var existingpath = ConfigurationManager.AppSettings["AttachFile"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    newsletterMail.AttachFile = myfile;
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
            var data = _iNewsletterMailManager.AddOrEdit(newsletterMail);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iNewsletterMailManager.GetAllNewsletterMail()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var imageName = _iNewsletterMailManager.GetANewsletterMail(id);

            var path = ConfigurationManager.AppSettings["AttachFile"];
            var finalpath = Path.Combine(Server.MapPath(path), imageName.AttachFile);

            if (System.IO.File.Exists(finalpath))
            {
                System.IO.File.Delete(finalpath);
            }
            var data = _iNewsletterMailManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iNewsletterMailManager.GetAllNewsletterMail()) }, JsonRequestBehavior.AllowGet);
        }
    }
}



 
   

        
        
 