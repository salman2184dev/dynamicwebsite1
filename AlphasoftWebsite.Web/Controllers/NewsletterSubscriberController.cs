using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.BLL.Manager;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Web.Controllers
{
    public class NewsletterSubscriberController : Controller
    {

        // GET: NewsletterSubscriber
        INewsletterSubscriberManager _iNewsletterSubscriberManager = new NewsletterSubscriberManager();
        INewsletterMailManager _iNewsletterMailManager = new NewsletterMailManager();
        ISmtpHostManager _iSmtpHostManager = new SmtpHostManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            //var newsLetterMailList = _iNewsletterMailManager.GetAllNewsletterMail().Select(x => new
            //{
            //    x.NewsletterMailId,
            //    x.Subject
            //}).ToList();

            //ViewBag.NewsletterMailId = new SelectList(newsLetterMailList, "NewsletterMailId", "Subject");
            var newsletterSubscriber = _iNewsletterSubscriberManager.GetAllNewsletterSubscriber();
            return View(newsletterSubscriber);
        }

        [HttpPost]
        public ActionResult ViewAll(FormCollection formCollection, int NewsletterMailId, int SmtpHostId)
        {
            MailMessage mailMessage = new MailMessage();
            
            SentMailLog sentMailLog = new SentMailLog();
            //List<SentMailLog> sentMailLogList= new List<SentMailLog>();
            //var newsLetterMailList = _iNewsletterMailManager.GetAllNewsletterMail().Select(x => new
            //{
            //    x.NewsletterMailId,
            //    x.Subject
            //}).ToList();

            //ViewBag.NewsletterMailId = new SelectList(newsLetterMailList, "NewsletterMailId", "Subject");
            NewsletterMail newsletterMail = _iNewsletterMailManager.GetANewsletterMail(NewsletterMailId);
            SmtpHost smtpHost = _iSmtpHostManager.GetASmtpHost(SmtpHostId);
            string[] ids = formCollection["NewsletterSubscriberId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                
                var newsletterSubscriber = _iNewsletterSubscriberManager.GetANewsletterSubscriber(int.Parse(id));
                if (newsletterSubscriber.IsActive==true)
                {
                    mailMessage.To.Add(new MailAddress(newsletterSubscriber.NewsletterSubscriberEmail));

                    //mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                    mailMessage.From = new MailAddress(smtpHost.UserName);
                    mailMessage.Subject = newsletterMail.Subject;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = newsletterMail.Body;

                    var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
                    string myfile = Path.GetFileName(newsletterMail.AttachFile);

                    var path = ConfigurationManager.AppSettings["AttachFile"];
                    var file = Path.Combine(Server.MapPath(path), myfile);
                    Attachment data = new Attachment(file);

                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(file);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(file);

                    mailMessage.Attachments.Add(data);
                    //mailMessage.DeliveryNotificationOptions= DeliveryNotificationOptions.OnSuccess;
                    SmtpClient client = new SmtpClient();
                    //client.Host = ConfigurationManager.AppSettings["Host"];
                    client.Host = smtpHost.HostType.HostName;
                    //client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    client.EnableSsl = smtpHost.HostType.EnableSsl; 
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    //NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                    NetworkCred.UserName = smtpHost.UserName;
                    //NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                    NetworkCred.Password = smtpHost.Password;
                    //string encryptedPassword = smtpHost.Password;
                    //string password = new EncryptionDecryption().Decrypt(smtpHost.UserName, encryptedPassword);

                    client.UseDefaultCredentials = true;
                    client.Credentials = NetworkCred;
                    //client.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    client.Port = int.Parse(smtpHost.HostType.PortNumber);


                    try
                    {
                        client.Send(mailMessage);
                        ViewBag.Result = "Mail Sent";
                        //if (ViewBag.Result==null)
                        //{
                        //    ViewBag.Result="Mail not sent" + newsletterSubscriber.NewsletterSubscriberEmail;
                        //}
                        sentMailLog.NewsletterSubscriberEmailId = newsletterSubscriber.NewsletterSubscriberEmail;
                        sentMailLog.NewsletterMailSubject = newsletterMail.Subject;
                        sentMailLog.CreatedBy = 1;
                        sentMailLog.CreatedDate = DateTime.Now;
                        sentMailLog.IsSent = true;
                        AlphasoftWebsiteContext db = new AlphasoftWebsiteContext();
                        db.SentMailLogs.Add(sentMailLog);
                        db.SaveChanges();
                    }
                    catch (SmtpFailedRecipientException ex)
                    {
                        ViewBag.Result = ex.Message;
                    }
                }
                
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            NewsletterSubscriber newsletterSubscriber = new NewsletterSubscriber();
            if (id != 0)
            {
                newsletterSubscriber = _iNewsletterSubscriberManager.GetANewsletterSubscriber(id);
            }
            return View(newsletterSubscriber);
        }

        [HttpPost]
        public ActionResult AddOrEdit(NewsletterSubscriber newsletterSubscriber)
        {
            var data = _iNewsletterSubscriberManager.AddOrEdit(newsletterSubscriber);       
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iNewsletterSubscriberManager.GetAllNewsletterSubscriber()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var data = _iNewsletterSubscriberManager.Delete(id);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iNewsletterSubscriberManager.GetAllNewsletterSubscriber()) }, JsonRequestBehavior.AllowGet);
        }
    }
}