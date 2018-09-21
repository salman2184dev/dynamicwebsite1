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
    public class FAQHeaderController : Controller
    {
        // GET: FAQHeader
        IFAQHeaderManager _iFAQHeaderManager = new FAQHeaderManager();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            var faqHeader = _iFAQHeaderManager.GetAllFaqHeader();
            return View(faqHeader);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            FAQHeader faqHeader = new FAQHeader();
            if (id != 0)
            {
                faqHeader = _iFAQHeaderManager.GetAFAQHeader(id);
            }
            return View(faqHeader);
        }

        [HttpPost]
        public ActionResult AddOrEdit(FAQHeader faqHeader)
        {
            var data = _iFAQHeaderManager.AddOrEdit(faqHeader);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFAQHeaderManager.GetAllFaqHeader()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iFAQHeaderManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFAQHeaderManager.GetAllFaqHeader()) }, JsonRequestBehavior.AllowGet);
        }

    }
}