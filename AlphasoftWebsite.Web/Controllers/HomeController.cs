using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.BLL.Manager;
using AlphasoftWebsite.Core.Model;
using Exception = System.Exception;

namespace AlphasoftWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        IWebSiteHomeManager _iWebSiteHomeManager = new WebSiteHomeManager();
        ICommonManager _iCommonManager = new CommonManager();
        IChatUserManager _iChatUserManager = new ChatUserManager();
        public ActionResult Index()
        {
         
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(ChatUser chatUser)
        {
            if (chatUser != null)
            {
                ChatUser user = new ChatUser();
                user.ChatUserName = chatUser.ChatUserName;

                using (AlphasoftWebsiteContext db = new AlphasoftWebsiteContext())
                {
                    db.ChatUsers.Add(user);
                    db.SaveChanges();
                }

                Session["UserName"] = chatUser.ChatUserName;
                return View();
            }
            return View();
        }

        public ActionResult ChatView()
        {
            return View();
        }

    }
} 