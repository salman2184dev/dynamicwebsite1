using System;
using System.Collections.Generic;
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
    public class SocialAccountTypeController : Controller
    {
        ISocialAccountTypeManager _iSocialAccountTypeManager = new SocialAccountTypeManager();

        // GET: SocialAccountType
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            var socialAccountType = _iSocialAccountTypeManager.GetAllSocialAccountType();
            return View(socialAccountType);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            SocialAccountType socialAccountType = new SocialAccountType();
            if (id != 0)
            {
                socialAccountType = _iSocialAccountTypeManager.GetASocialAccountType(id);
            }
            return View(socialAccountType);
        }

        [HttpPost]
        public ActionResult AddOrEdit(SocialAccountType socialAccountType)
        {
            //if (uploadedFile != null)
            //{
            //    string fileName = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
            //    string extension = Path.GetExtension(uploadedFile.FileName);
            //    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //    socialAccountType.SocialAccountTypeImage = "~/Image/SocialAccountType/" + fileName;
            //    uploadedFile.SaveAs(Path.Combine(Server.MapPath("~/Image/SocialAccountType/"), fileName));

            //}
            var data = _iSocialAccountTypeManager.AddOrEdit(socialAccountType);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iSocialAccountTypeManager.GetAllSocialAccountType()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iSocialAccountTypeManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iSocialAccountTypeManager.GetAllSocialAccountType()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnSocialAccountTypeById(int socialAccountTypeId)
        {
            var socialAccountType = _iSocialAccountTypeManager.GetASocialAccountType(socialAccountTypeId);
            var data = JsonConvert.SerializeObject(socialAccountType, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}