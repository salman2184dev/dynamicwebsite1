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
    public class SmtpHostController : Controller
    {
        // GET: SmtpHost
        ISmtpHostManager _iSmtpHostManager = new SmtpHostManager();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            var smtpHost = _iSmtpHostManager.GetAllSmtpHost();
            return View(smtpHost);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            //ViewBag.HostTypeId=
            SmtpHost smtpHost = new SmtpHost();
            if (id != 0)
            {
                smtpHost = _iSmtpHostManager.GetASmtpHost(id);
            }
            return View(smtpHost);
        }

        [HttpPost]
        public ActionResult AddOrEdit(SmtpHost smtpHost)
        {
            //HostType hostType = new AlphasoftWebsiteContext().HostTypes.FirstOrDefault(x => x.HostTypeId== HostTypeId);
            var data = _iSmtpHostManager.AddOrEdit(smtpHost);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iSmtpHostManager.GetAllSmtpHost()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iSmtpHostManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iSmtpHostManager.GetAllSmtpHost()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetASmtpHost(int smtpHostId)
        {
            var smtpHost = _iSmtpHostManager.GetASmtpHost(smtpHostId);
            //string encryptedPassword = smtpHost.Password;
            //string password = new EncryptionDecryption().Decrypt(smtpHost.UserName, encryptedPassword);
            //smtpHost.Password = password;
            var HostTypeId = smtpHost.HostTypeId;
            var data = new {HostTypeId};
            //var data = JsonConvert.SerializeObject(smtpHost, Formatting.None,
            //    new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}