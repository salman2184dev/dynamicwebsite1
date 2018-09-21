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
    public class ProductCategoryController : Controller
    {
        IProductCategoryManager _iProductCategoryManager = new ProductCategoryManager();
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var productCategory = _iProductCategoryManager.GetAllProductCategory();
            return View(productCategory);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            ProductCategory productCategory = new ProductCategory();
            if (id != 0)
            {
                productCategory = _iProductCategoryManager.GetAProductCategory(id);
            }
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult AddOrEdit(ProductCategory productCategory)
        {
            var data = _iProductCategoryManager.AddOrEdit(productCategory);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iProductCategoryManager.GetAllProductCategory()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iProductCategoryManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iProductCategoryManager.GetAllProductCategory()) }, JsonRequestBehavior.AllowGet);
        }

    }
}