using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IWebSiteHomeRepository
    {
        IEnumerable<Blog> GetAllBlogInfo();
       Blog GetABlogDetailsByID(int? blogId);

        IEnumerable<Software> GetAllSoftwareInfo();
        Software GetASoftwareDetailsByID(int? softwareId);

        IEnumerable<Product> GetAllProductInfo();
        Product GetAProductDetailsByID(int? productId);

        IEnumerable<HomeBanner> GetAllHomeBanners();
        IEnumerable<Service> GetAllServices();

        IEnumerable<FactorDetail> GetAllFactorDetail();
        IEnumerable<FactorHeader> GetAllFactorHeader();

        IEnumerable<FAQ> GetAllFAQ();

        IEnumerable<PricingDetail> GetAllPricingDetail();
        PricingDetail GetAPricingDetailsByID(int? pricingDetailId);

        IEnumerable<PricingTableType> GetAllPricingTable();

        IEnumerable<PricingDetailType> GetAllPricingDetailType();

        IEnumerable<Pricing> GetAllPricing();

        IEnumerable<CompanyDetail> GetAllCompanyDetail();
        IEnumerable<ClientList> GetAllClientList();
        IEnumerable<Client> GetAllClient();
        IEnumerable<OnlineUserFeedBackDetail> Contact();
    }
}
