using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.BLL.Manager;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;
using Newtonsoft.Json;

namespace AlphasoftWebsite.Web.Controllers
{
    public class BlogController : Controller
    {
        IBlogManager _iBlogManager = new BlogManager();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            var blog = _iBlogManager.GetAllBlog();
            return View(blog);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Blog blog = new Blog();
            if (id != 0)
            {
                blog = _iBlogManager.GetAnBlog(id);
            }
            return View(blog);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Blog blog, HttpPostedFileBase uploadedFile)
        {

            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "BlogImage" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["BlogImage"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (blog.BlogId > 0)
                    {
                        var imageName = blog.BlogImage;
                        var existingpath = ConfigurationManager.AppSettings["BlogImage"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    blog.BlogImage = myfile;
                    uploadedFile.SaveAs(finalpath);
                }
                else
                {
                    Message message = new Message();
                    message.ReturnMessage = "Choose only Image File!";
                    message.MessageType = MessageTypes.Information;
                }
            }
            else
            {
                Message message = new Message();
                message.ReturnMessage = "Select an Image!";
                message.MessageType = MessageTypes.Information;
            }
            var data = _iBlogManager.AddOrEdit(blog);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iBlogManager.GetAllBlog()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var imageName = _iBlogManager.GetAnBlog(id);
            var path = ConfigurationManager.AppSettings["BlogImage"];
            var finalpath = Path.Combine(Server.MapPath(path), imageName.BlogImage);

            if (System.IO.File.Exists(finalpath))
            {
                System.IO.File.Delete(finalpath);
            }
            var data = _iBlogManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iBlogManager.GetAllBlog()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnBlogById(int blogId)
        {
            var blog = _iBlogManager.GetAnBlog(blogId);
            var data = JsonConvert.SerializeObject(blog, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}