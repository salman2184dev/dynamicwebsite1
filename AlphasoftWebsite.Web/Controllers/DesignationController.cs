using System.Web.Mvc;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.BLL.Manager;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Web.Controllers
{
    public class DesignationController : Controller
    {
        IDesignationManager _iDesignationManager = new DesignationManager();
        // GET: Designation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            var designations = _iDesignationManager.GetAllDesignations();
            return View(designations);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Designation designation = new Designation();
            if (id != 0)
            {
                designation = _iDesignationManager.GetADesignation(id);
            }
            return View(designation);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Designation designation)
        {
            var data = _iDesignationManager.AddOrEdit(designation);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iDesignationManager.GetAllDesignations()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iDesignationManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iDesignationManager.GetAllDesignations()) }, JsonRequestBehavior.AllowGet);
        }

        
    }
}