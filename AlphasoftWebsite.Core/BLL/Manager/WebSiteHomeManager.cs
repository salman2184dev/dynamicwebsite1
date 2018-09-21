using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.DAL.Repository;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.BLL.Manager
{
    public class WebSiteHomeManager : IWebSiteHomeManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;

        private readonly IWebSiteHomeRepository _iWebSiteHomeRepository;

        public WebSiteHomeManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iWebSiteHomeRepository = new WebSiteHomeRepository(_AlphasoftWebsiteContext);
        }

        public Blog GetABlogDetailsByID(int? blogId)
        {
            try
            {

                var blogDetails = _iWebSiteHomeRepository.GetABlogDetailsByID(blogId);
                return blogDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Blog> GetAllBlogInfo()
        {
            try
            {

                var blogList = _iWebSiteHomeRepository.GetAllBlogInfo();
                return blogList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Product> GetAllProductInfo()
        {
            try
            {

                var productList = _iWebSiteHomeRepository.GetAllProductInfo();
                return productList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Software> GetAllSoftwareInfo()
        {
            try
            {

                var softwareList = _iWebSiteHomeRepository.GetAllSoftwareInfo();
                return softwareList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product GetAProductDetailsByID(int? productId)
        {
            try
            {
                var productDetails = _iWebSiteHomeRepository.GetAProductDetailsByID(productId);
                return productDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<HomeBanner> GetAllHomeBanners()
        {
            try
            {

                var homeBanners = _iWebSiteHomeRepository.GetAllHomeBanners();
                return homeBanners;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Software GetASoftwareDetailsByID(int? softwareId)
        {
            try
            {

                var softwareDetails = _iWebSiteHomeRepository.GetASoftwareDetailsByID(softwareId);
                return softwareDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Service> GetAllServices()
        {
            try
            {

                var services = _iWebSiteHomeRepository.GetAllServices();
                return services;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<FactorDetail> GetAllFactorDetail()
        {
            try
            {

                var factorDetail = _iWebSiteHomeRepository.GetAllFactorDetail();
                return factorDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<FactorHeader> GetAllFactorHeader()
        {
            try
            {

                var factorHeader = _iWebSiteHomeRepository.GetAllFactorHeader();
                return factorHeader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<FAQ> GetAllFAQ()
        {
            try
            {

                var faq = _iWebSiteHomeRepository.GetAllFAQ();
                return faq;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<PricingDetail> GetAllPricingDetail()
        {
            try
            {

                var pricingDetail = _iWebSiteHomeRepository.GetAllPricingDetail();
                return pricingDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PricingDetail GetAPricingDetailsByID(int? pricingDetailId)
        {
            try
            {

                var pricingDetail = _iWebSiteHomeRepository.GetAPricingDetailsByID(pricingDetailId);
                return pricingDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<PricingTableType> GetAllPricingTable()
        {
            try
            {

                var pricingTableType = _iWebSiteHomeRepository.GetAllPricingTable();
                return pricingTableType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<PricingDetailType> GetAllPricingDeatilType()
        {
            try
            {

                var pricingDetailType = _iWebSiteHomeRepository.GetAllPricingDetailType();
                return pricingDetailType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Pricing> GetAllPricing()
        {
            try
            {

                var pricing = _iWebSiteHomeRepository.GetAllPricing();
                return pricing;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<CompanyDetail> GetAllCompanyDetail()
        {
            try
            {

                var companyDetail = _iWebSiteHomeRepository.GetAllCompanyDetail();
                return companyDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<OnlineUserFeedBackDetail> Contact()
        {
            try
            {

                var contact = _iWebSiteHomeRepository.Contact();
                return contact;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<ClientList> GetAllClientList()
        {
            try
            {

                var clientList = _iWebSiteHomeRepository.GetAllClientList();
                return clientList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Client> GetAllClient()
        {
            try
            {

                var Client = _iWebSiteHomeRepository.GetAllClient();
                return Client;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
