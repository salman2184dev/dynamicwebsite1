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
    public class ServiceController : Controller
    {
        // GET: Service
        IServiceManager _iServiceManager = new ServiceManager();

       
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            var service = _iServiceManager.GetAllService();
            return View(service);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Service service = new Service();
            if (id != 0)
            {
                service = _iServiceManager.GetAService(id);
            }
            return View(service);
        }

   

        [HttpPost]
        public ActionResult AddOrEdit(Service service, HttpPostedFileBase uploadedFile)
        {

            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "ServiceImage" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["ServiceImage"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (service.ServiceId > 0)
                    {
                        var imageName = service.ServiceImage;
                        var existingpath = ConfigurationManager.AppSettings["ServiceImage"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    service.ServiceImage = myfile;
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
            var data = _iServiceManager.AddOrEdit(service);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iServiceManager.GetAllService()) }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(int id)
        {
            var imageName = _iServiceManager.GetAService(id);

            var path = ConfigurationManager.AppSettings["ServiceImage"];
            var finalpath = Path.Combine(Server.MapPath(path), imageName.ServiceImage);

            if (System.IO.File.Exists(finalpath))
            {
                System.IO.File.Delete(finalpath);
            }
            var data = _iServiceManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iServiceManager.GetAllService()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAServiceById(int serviceId)
        {
            var service = _iServiceManager.GetAService(serviceId);
            var data = JsonConvert.SerializeObject(service, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}