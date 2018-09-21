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
    public class ClientListController : Controller
    {
        // GET: ClientList

        IClientListManager _iClientListManager = new ClientListManager();
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            var clientList = _iClientListManager.GetAllClientList();
            return View(clientList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            ClientList clientList = new ClientList();
            if (id != 0)
            {
                clientList = _iClientListManager.GetAClientList(id);
            }
            return View(clientList);
        }

        [HttpPost]
        public ActionResult AddOrEdit(ClientList clientList, HttpPostedFileBase uploadedFile)
        {

            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "ClientListImage" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["ClientListImage"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (clientList.ClientID > 0)
                    {
                        var imageName = clientList.ClientImage;
                        var existingpath = ConfigurationManager.AppSettings["ClientListImage"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    clientList.ClientImage = myfile;
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
            var data = _iClientListManager.AddOrEdit(clientList);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iClientListManager.GetAllClientList()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var imageName = _iClientListManager.GetAClientList(id);
            var path = ConfigurationManager.AppSettings["ClientListImage"];
            var finalpath = Path.Combine(Server.MapPath(path), imageName.ClientImage);

            if (System.IO.File.Exists(finalpath))
            {
                System.IO.File.Delete(finalpath);
            }
            var data = _iClientListManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iClientListManager.GetAllClientList()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnClientListById(int clientListId)
        {
            var clientList = _iClientListManager.GetAClientList(clientListId);
            var data = JsonConvert.SerializeObject(clientList, Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}