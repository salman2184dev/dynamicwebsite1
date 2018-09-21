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
    public class FactorHeaderController : Controller
    {
        // GET: FactorHeader
        IFactorHeaderManager _iFactorHeaderManager = new FactorHeaderManager();
     
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var factorHeader = _iFactorHeaderManager.GetAllFactorHeader();
            return View(factorHeader);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            FactorHeader factorHeader = new FactorHeader();
            if (id != 0)
            {
                factorHeader = _iFactorHeaderManager.GetFactorHeader(id);
            }
            return View(factorHeader);
        }

        [HttpPost]
        public ActionResult AddOrEdit(FactorHeader factorHeader)
        {
            var data = _iFactorHeaderManager.AddOrEdit(factorHeader);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFactorHeaderManager.GetAllFactorHeader()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iFactorHeaderManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFactorHeaderManager.GetAllFactorHeader()) }, JsonRequestBehavior.AllowGet);
        }
    }
}