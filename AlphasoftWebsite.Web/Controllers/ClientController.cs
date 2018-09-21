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
    public class ClientController : Controller
    {
        // GET: Client
        IClientManager _iClientManager = new ClientManager();
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            var client = _iClientManager.GetAllClient();
            return View(client);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            Client client = new Client();
            if (id != 0)
            {
                client = _iClientManager.GetAClient(id);
            }
            return View(client);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Client client, HttpPostedFileBase uploadedFile)
        {

            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "ClientBackgroundImage" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["ClientBackgroundImage"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (client.ClientID > 0)
                    {
                        var imageName = client.ClientBackgroundImage;
                        var existingpath = ConfigurationManager.AppSettings["ClientBackgroundImage"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    client.ClientBackgroundImage = myfile;
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
            var data = _iClientManager.AddOrEdit(client);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iClientManager.GetAllClient()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var imageName = _iClientManager.GetAClient(id);
            var path = ConfigurationManager.AppSettings["ClientBackgroundImage"];
            var finalpath = Path.Combine(Server.MapPath(path), imageName.ClientBackgroundImage);

            if (System.IO.File.Exists(finalpath))
            {
                System.IO.File.Delete(finalpath);
            }
            var data = _iClientManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iClientManager.GetAllClient()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnClientById(int clientId)
        {
            var client = _iClientManager.GetAClient(clientId);
            var data = JsonConvert.SerializeObject(client, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}