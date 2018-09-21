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
    public class FactorDetailController : Controller
    {
        IFactorDetailManager _iFactorDetailManager = new FactorDetailManager();
        // GET: FactorDetail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var factorDetail = _iFactorDetailManager.GetAllFactorDetail();
            return View(factorDetail);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            FactorDetail factorDetail = new FactorDetail();
            if (id != 0)
            {
                factorDetail = _iFactorDetailManager.GetAFactorDetail(id);
            }
            return View(factorDetail);
        }

        [HttpPost]
        public ActionResult AddOrEdit(FactorDetail factorDetail)
        {
           
            var data = _iFactorDetailManager.AddOrEdit(factorDetail);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFactorDetailManager.GetAllFactorDetail()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iFactorDetailManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFactorDetailManager.GetAllFactorDetail()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnFactorDetailById(int factorDetailId)
        {
            var factorDetail = _iFactorDetailManager.GetAFactorDetail(factorDetailId);
            var data = JsonConvert.SerializeObject(factorDetail, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}