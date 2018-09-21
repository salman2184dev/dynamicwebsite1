using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IPricingRepository
    {
        int AddOrEdit(Pricing pricing);
        IEnumerable<Pricing> GetAllPricing();
        int Delete(int pricingId);
        Pricing GetAPricing(int pricingId);
    }
}
