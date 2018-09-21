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
    public class HomeBannerController : Controller
    {
        IHomeBannerManager _iHomeBannerManager = new HomeBannerManager();
        // GET: HomeBanner
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            var homeBanner = _iHomeBannerManager.GetAllHomeBanner();
            return View(homeBanner);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            HomeBanner homeBanner = new HomeBanner();
            if (id != 0)
            {
                homeBanner = _iHomeBannerManager.GetAHomeBanner(id);
            }
            return View(homeBanner);
        }

        [HttpPost]
        public ActionResult AddOrEdit(HomeBanner homeBanner, HttpPostedFileBase uploadedFile)
        {
            
            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {              
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "HomeBannerImage" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["HomeBannerImage"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (homeBanner.HomeBannerId > 0)
                    {
                        var imageName = homeBanner.HomeBannerImage;
                        var existingpath = ConfigurationManager.AppSettings["HomeBannerImage"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    homeBanner.HomeBannerImage = myfile;                                      
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
            var data = _iHomeBannerManager.AddOrEdit(homeBanner);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iHomeBannerManager.GetAllHomeBanner()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var imageName = _iHomeBannerManager.GetAHomeBanner(id);
          
            var path = ConfigurationManager.AppSettings["HomeBannerImage"];
            var finalpath = Path.Combine(Server.MapPath(path), imageName.HomeBannerImage);

            if (System.IO.File.Exists(finalpath))
            {
                System.IO.File.Delete(finalpath);
            }
            var data = _iHomeBannerManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iHomeBannerManager.GetAllHomeBanner()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAHomeBannerById(int homeBannerId)
        {
            var homeBanner = _iHomeBannerManager.GetAHomeBanner(homeBannerId);
            var data = JsonConvert.SerializeObject(homeBanner, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}