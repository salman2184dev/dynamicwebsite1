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
    public class ProductController : Controller
    {
        IProductManager _iProductManager = new ProductManager();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            var product = _iProductManager.GetAllProduct();
            return View(product);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Product product = new Product();
            if (id != 0)
            {
                product = _iProductManager.GetAnProduct(id);
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Product product, HttpPostedFileBase uploadedFile)
        {

            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "ProductImage" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["ProductImage"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (product.ProductId > 0)
                    {
                        var imageName = product.ProductImage;
                        var existingpath = ConfigurationManager.AppSettings["ProductImage"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    product.ProductImage = myfile;
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
            var data = _iProductManager.AddOrEdit(product);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iProductManager.GetAllProduct()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var imageName = _iProductManager.GetAnProduct(id);

            var path = ConfigurationManager.AppSettings["ProductImage"];
            var finalpath = Path.Combine(Server.MapPath(path), imageName.ProductImage);

            if (System.IO.File.Exists(finalpath))
            {
                System.IO.File.Delete(finalpath);
            }
            var data = _iProductManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iProductManager.GetAllProduct()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnProductById(int productId)
        {
            var product = _iProductManager.GetAnProduct(productId);
            var data = JsonConvert.SerializeObject(product, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}