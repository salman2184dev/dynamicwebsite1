using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IPricingDetailTypeManager
    {
        Message AddOrEdit(PricingDetailType pricingDetailType);
        IEnumerable<PricingDetailType> GetAllPricingDetailType();
        Message Delete(int pricingDetailTypeId);
        PricingDetailType GetAPricingDetailType(int pricingDetailTypeId);
    }
}
