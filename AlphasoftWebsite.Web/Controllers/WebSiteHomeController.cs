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
    public class WebSiteHomeController : Controller
    {
        IWebSiteHomeManager _iWebSiteHomeManager = new WebSiteHomeManager();  
        IBlogCategoryManager _iBlogCategoryManager= new BlogCategoryManager();
        ISoftwareCategoryManager _iSoftwareCategoryManager = new SoftwareCategoryManager();

        IPricingTableTypeManager _iPricingTableTypeManager = new PricingTableTypeManager();
        IPricingDetailTypeManager _iPricingDetailTypeManager = new PricingDetailTypeManager();
        IPricingDetailManager _iPricingDetailManager = new PricingDetailManager();
        IPricingManager _iPricingManager = new PricingManager();
        IOnlineUserFeedBackDetailManager _iOnlineUserFeedBackDetailManager = new OnlineUserFeedBackDetailManager();

        IProductCategoryManager _iProductCategoryManager = new ProductCategoryManager();
        IServicePropertyManager _iServicePropertyManager = new ServicePropertyManager();   
        IFactorHeaderManager _iFactorHeaderManager = new FactorHeaderManager();
        ICompanyDetailManager _iCompanyDetailManager = new CompanyDetailManager();
        IFAQManager _iFaqManager = new FAQManager();
        IClientListManager _iClientListManager = new ClientListManager();
        IClientManager _iClientManager = new ClientManager();
        ICommonManager _iCommonManager = new CommonManager();
        // GET: WebSiteHome
        public ActionResult Index()
        {
            ViewBag.MainBanner = _iWebSiteHomeManager.GetAllHomeBanners().Where(a => a.IsActive).OrderBy(a=>a.SerialNo).ToList();
            ViewBag.PricingTableType = _iWebSiteHomeManager.GetAllPricingTable().ToList();
           // ViewBag.PricingDetailType = _iWebSiteHomeManager.GetAllPricingDeatilType().ToList();
            ViewBag.Pricing = _iWebSiteHomeManager.GetAllPricing().OrderByDescending(a=>a.CreatedDate).Take(1).ToList();
            ViewBag.PricingDetail = _iWebSiteHomeManager.GetAllPricingDetail().ToList();
            ViewBag.Factor = _iWebSiteHomeManager.GetAllFactorDetail().Where(a => a.IsActive).ToList();
            ViewBag.FactorHeader = _iWebSiteHomeManager.GetAllFactorHeader().OrderByDescending(a => a.CreatedDate).Take(1).ToList();
            ViewBag.Services = _iWebSiteHomeManager.GetAllServices().Where(a => a.IsActive).ToList();
            ViewBag.Client = _iWebSiteHomeManager.GetAllClient().Where(a => a.IsActive).ToList();
            ViewBag.ClientList = _iWebSiteHomeManager.GetAllClientList().Where(a => a.IsActive).ToList();
            return View();
        }
        public ActionResult BlogList()
        {
            var data = _iWebSiteHomeManager.GetAllBlogInfo().Where(a => a.IsActive).ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult GetABlogDetailsByID(int? blogId)
        {
            var data = _iWebSiteHomeManager.GetABlogDetailsByID(blogId);
            ViewBag.BlogCategoryList = _iBlogCategoryManager.GetAllBlogCategory();
            ViewBag.BlogList = _iWebSiteHomeManager.GetAllBlogInfo().Take(3).ToList();
            return View(data);
        }

        public ActionResult SoftwareList()
        {
            var data = _iWebSiteHomeManager.GetAllSoftwareInfo().Where(a => a.IsActive).ToList();
            ViewBag.SoftwareCategoryList = _iSoftwareCategoryManager.GetAllSoftwareCategory();
            return View(data);
        }
        public ActionResult ServicesList()
        {
         
  
         
            ViewBag.Services = _iWebSiteHomeManager.GetAllServices().Where(a => a.IsActive).ToList();
            ViewBag.Factor = _iWebSiteHomeManager.GetAllFactorDetail().Where(a => a.IsActive).ToList();
            ViewBag.FactorHeader = _iWebSiteHomeManager.GetAllFactorHeader().OrderByDescending(a=>a.CreatedDate).Take(1).ToList();
            //ViewBag.IconList = _iIconListManager.GetAllIconList();
         
            return View();
        }

        [HttpGet]
        public ActionResult GetASoftwareDetailsById(int? softwareId)
        {
            var data = _iWebSiteHomeManager.GetASoftwareDetailsByID(softwareId);
            ViewBag.SoftwareCategoryList = _iSoftwareCategoryManager.GetAllSoftwareCategory();
            ViewBag.SoftwareList = _iWebSiteHomeManager.GetAllSoftwareInfo().Take(3).ToList();
            return View(data);
        }

        public ActionResult ProductList()
        {
            var data = _iWebSiteHomeManager.GetAllProductInfo().Where(a=>a.IsActive).ToList();
            ViewBag.ProductCategoryList = _iProductCategoryManager.GetAllProductCategory();
            return View(data);
        }

        [HttpGet]
        public ActionResult GetAProductDetailsById(int? productId)
        {
            var data = _iWebSiteHomeManager.GetAProductDetailsByID(productId);
            ViewBag.ProductCategoryList = _iProductCategoryManager.GetAllProductCategory();
            ViewBag.ProductList = _iWebSiteHomeManager.GetAllProductInfo().Take(3).ToList();
            return View(data);
        }
        
        public ActionResult FAQList()
        {

            ViewBag.faq = _iWebSiteHomeManager.GetAllFAQ().Where(a => a.IsActive).ToList();                  
            return View();
        }
        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contact(OnlineUserFeedBackDetail onlineUserFeedBackDetail)
        {
            var data = _iOnlineUserFeedBackDetailManager.AddOrEdit(onlineUserFeedBackDetail);
            return Json(data, JsonRequestBehavior.AllowGet);
        }



    }
}