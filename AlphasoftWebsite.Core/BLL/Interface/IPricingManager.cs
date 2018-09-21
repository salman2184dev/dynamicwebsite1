using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IPricingManager
    {
        Message AddOrEdit(Pricing pricing);
        IEnumerable<Pricing> GetAllPricing();
        Message Delete(int pricingId);
        Pricing GetAPricing(int pricingId);
    }
}
