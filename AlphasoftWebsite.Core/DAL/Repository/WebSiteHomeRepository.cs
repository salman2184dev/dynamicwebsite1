using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;
using PagedList;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class WebSiteHomeRepository : IWebSiteHomeRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public WebSiteHomeRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Blog GetABlogDetailsByID(int? blogId)
        {
            
                var blog = _dbContext.Blogs.Include(a => a.BlogCategory).FirstOrDefault(x => x.BlogId == blogId);
                return blog;
            
        }

        public IEnumerable<Blog> GetAllBlogInfo()
        {
            var blogList = _dbContext.Blogs.Include(a=>a.BlogCategory).ToList();
            return blogList;
        }

        public IEnumerable<Product> GetAllProductInfo()
        {
            var productList = _dbContext.Products.Include(a => a.ProductCategory).ToList();
            return productList;
        }

        public IEnumerable<Software> GetAllSoftwareInfo()
        {
            var SoftwareList = _dbContext.Softwares.Include(a => a.SoftwareCategory).ToList();
            return SoftwareList;
        }

        public Product GetAProductDetailsByID(int? productId)
        {
            var product = _dbContext.Products.Include(a => a.ProductCategory).FirstOrDefault(x => x.ProductId == productId);
            return product;
        }

        public IEnumerable<HomeBanner> GetAllHomeBanners()
        {
            var mainBanner = _dbContext.HomeBanners.OrderBy(a=>a.SerialNo).ToList();
            return mainBanner;
        }

        public Software GetASoftwareDetailsByID(int? softwareId)
        {
            var software = _dbContext.Softwares.Include(a => a.SoftwareCategory).FirstOrDefault(x => x.SoftwareId == softwareId);
            return software;
        }

        public IEnumerable<Service> GetAllServices()
        {
            var services = _dbContext.Services.Include(a => a.ServiceProperties).ToList();
            return services;
        }

        public IEnumerable<FactorDetail> GetAllFactorDetail()
        {
            var factorDetails = _dbContext.FactorDetails.Include(a => a.IconList).ToList();
            return factorDetails;
        }

        public IEnumerable<FactorHeader> GetAllFactorHeader()
        {
            var factorHeader = _dbContext.FactorHeaders.ToList();
            return factorHeader;
        }

        public IEnumerable<FAQ> GetAllFAQ()
        {
            var faq = _dbContext.FAQs.ToList();
            return faq;
        }

        public IEnumerable<PricingDetail> GetAllPricingDetail()
        {
            var pricingDetail = _dbContext.PricingDetails.Include(a => a.PricingTableType).Include(a=>a.PricingDetailType).ToList();
            return pricingDetail;
        }

        public PricingDetail GetAPricingDetailsByID(int? pricingDetailId)
        {
            var pricingDetail = _dbContext.PricingDetails.Include(a => a.PricingTableType).Include(a=>a.PricingDetailType).FirstOrDefault(x => x.PricingDetailID == pricingDetailId);
            return pricingDetail;
        }

        public IEnumerable<PricingTableType> GetAllPricingTable()
        {
         var pricingTableType = _dbContext.PricingTableTypes.ToList();
            return pricingTableType;
        }

        public IEnumerable<PricingDetailType> GetAllPricingDetailType()
        {
            var pricingDetailType = _dbContext.PricingDetailTypes.ToList();
            return pricingDetailType;
        }

        public IEnumerable<Pricing> GetAllPricing()
        {
            var pricing = _dbContext.Pricings.ToList();
            return pricing;
        }

        public IEnumerable<CompanyDetail> GetAllCompanyDetail()
        {
            var companyDetail = _dbContext.CompanyDetails.ToList();
            return companyDetail;
        }

        public IEnumerable<OnlineUserFeedBackDetail> Contact()
        {
            var contact = _dbContext.OnlineUserFeedBackDetails.ToList();
            return contact;
        }

        public IEnumerable<ClientList> GetAllClientList()
        {
            var clientList = _dbContext.ClientLists.ToList();
            return clientList;
        }

        public IEnumerable<Client> GetAllClient()
        {
            var Client = _dbContext.Clients.ToList();
            return Client;
        }
    }
}