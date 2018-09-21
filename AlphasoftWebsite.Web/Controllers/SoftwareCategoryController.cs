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
    public class SoftwareCategoryController : Controller
    {
        // GET: SoftwareCategory
        ISoftwareCategoryManager _iSoftwareCategoryManager = new SoftwareCategoryManager();
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var softwareCategory = _iSoftwareCategoryManager.GetAllSoftwareCategory();
            return View(softwareCategory);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            SoftwareCategory softwareCategory = new SoftwareCategory();
            if (id != 0)
            {
                softwareCategory = _iSoftwareCategoryManager.GetASoftwareCategory(id);
            }
            return View(softwareCategory);
        }

        [HttpPost]
        public ActionResult AddOrEdit(SoftwareCategory softwareCategory)
        {
            var data = _iSoftwareCategoryManager.AddOrEdit(softwareCategory);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iSoftwareCategoryManager.GetAllSoftwareCategory()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iSoftwareCategoryManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iSoftwareCategoryManager.GetAllSoftwareCategory()) }, JsonRequestBehavior.AllowGet);
        }
    }
}