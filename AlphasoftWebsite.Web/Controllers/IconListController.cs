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
    public class IconListController : Controller
    {
        IIconListManager _iIconListManager = new IconListManager();
        // GET: IconList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var iconList = _iIconListManager.GetAllIconList();
            return View(iconList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            IconList iconList = new IconList();
            if (id != 0)
            {
                iconList = _iIconListManager.GetAnIconList(id);
            }
            return View(iconList);
        }

        [HttpPost]
        public ActionResult AddOrEdit(IconList iconList)
        {
            var data = _iIconListManager.AddOrEdit(iconList);        
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iIconListManager.GetAllIconList()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iIconListManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iIconListManager.GetAllIconList()) }, JsonRequestBehavior.AllowGet);
        }

    }
}