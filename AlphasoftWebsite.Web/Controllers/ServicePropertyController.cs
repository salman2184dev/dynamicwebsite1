using System;
using System.Collections.Generic;
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
    public class ServicePropertyController : Controller
    {
        // GET: ServiceProperty

        IServicePropertyManager _iServicePropertyManager = new ServicePropertyManager();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            var serviceProperty = _iServicePropertyManager.GetAllServiceProperty();
            return View(serviceProperty);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            ServiceProperty serviceProperty = new ServiceProperty();
            if (id != 0)
            {
                serviceProperty = _iServicePropertyManager.GetAServiceProperty(id);
            }
            return View(serviceProperty);
        }

        [HttpPost]
        public ActionResult AddOrEdit(ServiceProperty serviceProperty)
        {
            //if (uploadedFile != null)
            //{
            //    string fileName = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
            //    string extension = Path.GetExtension(uploadedFile.FileName);
            //    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //    socialAccountType.SocialAccountTypeImage = "~/Image/SocialAccountType/" + fileName;
            //    uploadedFile.SaveAs(Path.Combine(Server.MapPath("~/Image/SocialAccountType/"), fileName));

            //}
            var data = _iServicePropertyManager.AddOrEdit(serviceProperty);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iServicePropertyManager.GetAllServiceProperty()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iServicePropertyManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iServicePropertyManager.GetAllServiceProperty()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAServicePropertyById(int servicePropertyId)
        {
            var serviceProperty = _iServicePropertyManager.GetAServiceProperty(servicePropertyId);
            var data = JsonConvert.SerializeObject(serviceProperty, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}