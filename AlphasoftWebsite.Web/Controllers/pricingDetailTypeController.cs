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
    public class pricingDetailTypeController : Controller
    {
        // GET: pricingDetailType
        IPricingDetailTypeManager _iPricingDetailTypeManager = new PricingDetailTypeManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var pricingDetailType = _iPricingDetailTypeManager.GetAllPricingDetailType();
            return View(pricingDetailType);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            PricingDetailType pricingDetailType = new PricingDetailType();
            if (id != 0)
            {
                pricingDetailType = _iPricingDetailTypeManager.GetAPricingDetailType(id);
            }
            return View(pricingDetailType);
        }

        [HttpPost]
        public ActionResult AddOrEdit(PricingDetailType pricingDetailType)
        {
            var data = _iPricingDetailTypeManager.AddOrEdit(pricingDetailType);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iPricingDetailTypeManager.GetAllPricingDetailType()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iPricingDetailTypeManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iPricingDetailTypeManager.GetAllPricingDetailType()) }, JsonRequestBehavior.AllowGet);
        }
    }
}