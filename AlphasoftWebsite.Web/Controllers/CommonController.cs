using System.Web.Mvc;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.BLL.Manager;

namespace AlphasoftWebsite.Web.Controllers
{
    public class CommonController : Controller
    {
        ICommonManager _iCommonManager = new CommonManager();
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllDesignations(int? identityCode)
        {
            var data = _iCommonManager.GetAllDesignations(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllProductCategories(int? identityCode)
        {
            var data = _iCommonManager.GetAllProductCategories(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllBlogCategories(int? identityCode)
        {
            var data = _iCommonManager.GetAllBlogCategories(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllIconList(int? identityCode)
        {
            var data = _iCommonManager.GetAllIconList(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllCompanyList(int? identityCode)
        {
            var data = _iCommonManager.GetAllCompanyList(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllSocialAccountTypeList(int? identityCode)
        {
            var data = _iCommonManager.GetAllSocialAccountTypeList(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllSoftwareCategories(int? identityCode)
        {
            var data = _iCommonManager.GetAllSoftwareCategories(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllService(int? identityCode)
        {
            var data = _iCommonManager.GetAllService(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllNewsLetterEmails(int? identityCode)
        {
            var data = _iCommonManager.GetAllNewsLetterEmails(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllSmtpHosts(int? identityCode)
        {
            var data = _iCommonManager.GetAllSmtpHosts(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllHostTypes(int? identityCode)
        {
            var data = _iCommonManager.GetAllHostTypes(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllPricingTableType(int? identityCode)
        {
            var data = _iCommonManager.GetAllPricingTableType(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllPricingDetailType(int? identityCode)
        {
            var data = _iCommonManager.GetAllPricingDetailType(identityCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}