using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IPricingDetailManager
    {
        Message AddOrEdit(PricingDetail pricingDetail);
        IEnumerable<PricingDetail> GetAllPricingDetail();
        Message Delete(int pricingDetailId);
        PricingDetail GetAPricingDetail(int pricingDetailId);
    }
}
