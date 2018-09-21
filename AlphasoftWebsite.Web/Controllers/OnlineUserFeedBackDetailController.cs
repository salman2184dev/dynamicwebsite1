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
    public class OnlineUserFeedBackDetailController : Controller
    {
        IOnlineUserFeedBackDetailManager _iOnlineUserFeedBackDetailManager = new OnlineUserFeedBackDetailManager();

        // GET: OnlineUserFeedBackDetail
        public ActionResult Index()
        {
            return View();
        }

     





    }
}