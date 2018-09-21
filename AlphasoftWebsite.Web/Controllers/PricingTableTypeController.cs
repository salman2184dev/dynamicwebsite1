using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.BLL.Manager;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Web.Controllers
{
    public class PricingTableTypeController : Controller
    {
        // GET: PricingTableType
        IPricingTableTypeManager _iPricingTableTypeManager = new PricingTableTypeManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var pricingTableType = _iPricingTableTypeManager.GetAllPricingTableType();
            return View(pricingTableType);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            PricingTableType pricingTableType = new PricingTableType();
            if (id != 0)
            {
                pricingTableType = _iPricingTableTypeManager.GetAPricingTableType(id);
            }
            return View(pricingTableType);
        }

        [HttpPost]
        public ActionResult AddOrEdit(PricingTableType pricingTableType)
        {
            var data = _iPricingTableTypeManager.AddOrEdit(pricingTableType);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iPricingTableTypeManager.GetAllPricingTableType()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iPricingTableTypeManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iPricingTableTypeManager.GetAllPricingTableType()) }, JsonRequestBehavior.AllowGet);
        }
    }
}