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
    public class PricingController : Controller
    {
        // GET: Pricing
        
        IPricingManager _iPricingManager = new PricingManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var pricing = _iPricingManager.GetAllPricing();
            return View(pricing);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Pricing pricing = new Pricing();
            if (id != 0)
            {
                pricing = _iPricingManager.GetAPricing(id);
            }
            return View(pricing);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Pricing pricing)
        {
            var data = _iPricingManager.AddOrEdit(pricing);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iPricingManager.GetAllPricing()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iPricingManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iPricingManager.GetAllPricing()) }, JsonRequestBehavior.AllowGet);
        }
    }
}