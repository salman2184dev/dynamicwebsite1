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
    public class CompanySocialAccountDetailController : Controller
    {
      
        ICompanySocialAccountDetailManager _iCompanySocialAccountDetailManager = new CompanySocialAccountDetailManager();
        // GET: CompanySocialAccountDetail
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            var companySocialAccountDetail = _iCompanySocialAccountDetailManager.GetAllCompanySocialAccountDetail();
            return View(companySocialAccountDetail);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            CompanySocialAccountDetail companySocialAccountDetail = new CompanySocialAccountDetail();
            if (id != 0)
            {
                companySocialAccountDetail = _iCompanySocialAccountDetailManager.GetACompanySocialAccountDetail(id);
            }
            return View(companySocialAccountDetail);
        }

        [HttpPost]
        public ActionResult AddOrEdit(CompanySocialAccountDetail companySocialAccountDetail)
        {
            //if (uploadedFile != null)
            //{
            //    string fileName = Path.GetFileNameWithoutExtension(uploadedFile.FileName);
            //    string extension = Path.GetExtension(uploadedFile.FileName);
            //    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //    companySocialAccountDetail.CompanySocialAccountDetailImage = "~/Image/CompanySocialAccountDetail/" + fileName;
            //    uploadedFile.SaveAs(Path.Combine(Server.MapPath("~/Image/CompanySocialAccountDetail/"), fileName));

            //}
            var data = _iCompanySocialAccountDetailManager.AddOrEdit(companySocialAccountDetail);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iCompanySocialAccountDetailManager.GetAllCompanySocialAccountDetail()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iCompanySocialAccountDetailManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iCompanySocialAccountDetailManager.GetAllCompanySocialAccountDetail()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnCompanySocialAccountDetailById(int companySocialAccountDetailId)
        {
            var companySocialAccountDetail = _iCompanySocialAccountDetailManager.GetACompanySocialAccountDetail(companySocialAccountDetailId);
            var data = JsonConvert.SerializeObject(companySocialAccountDetail, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}