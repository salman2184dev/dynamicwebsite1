using System.Web.Mvc;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.BLL.Manager;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Web.Controllers
{
    public class FAQController : Controller
    {
        IFAQManager _iFAQManager = new FAQManager();
        // GET: FAQ
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            var FAQs = _iFAQManager.GetAllFAQs();
            return View(FAQs);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            FAQ FAQ = new FAQ();
            if (id != 0)
            {
                FAQ = _iFAQManager.GetAnFAQ(id);
            }
            return View(FAQ);
        }

        [HttpPost]
        public ActionResult AddOrEdit(FAQ FAQ)
        {
            var data = _iFAQManager.AddOrEdit(FAQ);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFAQManager.GetAllFAQs()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iFAQManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iFAQManager.GetAllFAQs()) }, JsonRequestBehavior.AllowGet);
        }


    }
}