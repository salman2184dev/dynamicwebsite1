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

namespace AlphasoftWebsite.Web.Controllers
{
    public class CompanyDetailController : Controller
    {
        ICompanyDetailManager _iCompanyDetailManager = new CompanyDetailManager();

        // GET: CompanyDetail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            var companyDetail = _iCompanyDetailManager.GetAllCompanyDetail();
            return View(companyDetail);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            CompanyDetail companyDetail = new CompanyDetail();
            if (id != 0)
            {
                companyDetail = _iCompanyDetailManager.GetACompanyDetail(id);
            }
            return View(companyDetail);
        }

        [HttpPost]
        public ActionResult AddOrEdit(CompanyDetail companyDetail, HttpPostedFileBase uploadedFile)
        {

            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "CompanyImage" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["CompanyImage"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (companyDetail.CompanyId > 0)
                    {
                        var imageName = companyDetail.CompanyImage;
                        var existingpath = ConfigurationManager.AppSettings["CompanyImage"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    companyDetail.CompanyImage = myfile;
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
            var data = _iCompanyDetailManager.AddOrEdit(companyDetail);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iCompanyDetailManager.GetAllCompanyDetail()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var imageName = _iCompanyDetailManager.GetACompanyDetail(id);

            var path = ConfigurationManager.AppSettings["CompanyImage"];
            var finalpath = Path.Combine(Server.MapPath(path), imageName.CompanyImage);

            if (System.IO.File.Exists(finalpath))
            {
                System.IO.File.Delete(finalpath);
            }
            var data = _iCompanyDetailManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iCompanyDetailManager.GetAllCompanyDetail()) }, JsonRequestBehavior.AllowGet);
        }
    }
}