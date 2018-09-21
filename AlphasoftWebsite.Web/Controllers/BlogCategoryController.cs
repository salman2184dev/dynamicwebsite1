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
    public class BlogCategoryController : Controller
    {
        IBlogCategoryManager _iBlogCategoryManager = new BlogCategoryManager();
        // GET: BlogCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var blogCategory = _iBlogCategoryManager.GetAllBlogCategory();
            return View(blogCategory);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            BlogCategory blogCategory = new BlogCategory();
            if (id != 0)
            {
                blogCategory = _iBlogCategoryManager.GetABlogCategory(id);
            }
            return View(blogCategory);
        }

        [HttpPost]
        public ActionResult AddOrEdit(BlogCategory blogCategory)
        {
            var data = _iBlogCategoryManager.AddOrEdit(blogCategory);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iBlogCategoryManager.GetAllBlogCategory()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iBlogCategoryManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iBlogCategoryManager.GetAllBlogCategory()) }, JsonRequestBehavior.AllowGet);
        }

    }
}