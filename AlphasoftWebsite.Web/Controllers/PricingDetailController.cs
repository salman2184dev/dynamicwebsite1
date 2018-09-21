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
    public class PricingDetailController : Controller
    {
        // GET: PricingDetail
        IPricingDetailManager _iPricingDetailManager = new PricingDetailManager();
        IPricingTableTypeManager _iPricingTableTypeManager= new PricingTableTypeManager();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            var pricingDetail = _iPricingDetailManager.GetAllPricingDetail();
            return View(pricingDetail);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            PricingDetail pricingDetail = new PricingDetail();
            if (id != 0)
            {
                pricingDetail = _iPricingDetailManager.GetAPricingDetail(id);
            }
            return View(pricingDetail);
        }

        [HttpPost]
        public ActionResult AddOrEdit(PricingDetail pricingDetail)
        {
            var data = _iPricingDetailManager.AddOrEdit(pricingDetail);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iPricingDetailManager.GetAllPricingDetail()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iPricingDetailManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iPricingDetailManager.GetAllPricingDetail()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAPricingDetailById(int pricingDetailId)
        {
            var pricingDetail = _iPricingDetailManager.GetAPricingDetail(pricingDetailId);
            var pttID = pricingDetail.PricingTableTypeID;
            var pdtID = pricingDetail.PricingDetailTypeID;
            var data = new {pttID, pdtID};
            //var pricingTable = _iPricingTableTypeManager.GetAPricingTableType(pricingDetailId);
            //var data = JsonConvert.SerializeObject(pricingDetail, Formatting.None,
            //    new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        
    }
}