using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IPricingTableTypeManager
    {
        Message AddOrEdit(PricingTableType pricingTableType);
        IEnumerable<PricingTableType> GetAllPricingTableType();
        Message Delete(int pricingTableTypeId);
        PricingTableType GetAPricingTableType(int pricingTableTypeId);
    }
}
