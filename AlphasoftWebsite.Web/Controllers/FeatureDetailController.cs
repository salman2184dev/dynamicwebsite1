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
    public class FeatureDetailController : Controller
    {
        IFeatureDetailManager _iFeatureDetailManager = new FeatureDetailManager();
        // GET: FeatureDetail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var featureDetail = _iFeatureDetailManager.GetAllFeatureDetail();
            return View(featureDetail);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            FeatureDetail featureDetail = new FeatureDetail();
            if (id != 0)
            {
                featureDetail = _iFeatureDetailManager.GetAFeatureDetail(id);
            }
            return View(featureDetail);
        }

        [HttpPost]
        public ActionResult AddOrEdit(FeatureDetail featureDetail)
        {

            var data = _iFeatureDetailManager.AddOrEdit(featureDetail);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFeatureDetailManager.GetAllFeatureDetail()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iFeatureDetailManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFeatureDetailManager.GetAllFeatureDetail()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnFeatureDetailById(int featureDetailId)
        {
            var featureDetail = _iFeatureDetailManager.GetAFeatureDetail(featureDetailId);
            var data = JsonConvert.SerializeObject(featureDetail, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}