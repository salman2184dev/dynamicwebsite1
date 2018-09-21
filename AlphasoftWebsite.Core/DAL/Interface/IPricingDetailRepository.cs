using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IPricingDetailRepository
    {
        int AddOrEdit(PricingDetail pricingDetail);
        IEnumerable<PricingDetail> GetAllPricingDetail();
        int Delete(int pricingDetailId);
        PricingDetail GetAPricingDetail(int pricingDetailId);
    }
}
