using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IPricingTableTypeRepository
    {
        int AddOrEdit(PricingTableType pricingTableType);
        IEnumerable<PricingTableType> GetAllPricingTableType();
        int Delete(int pricingTableTypeId);
        PricingTableType GetAPricingTableType(int pricingTableTypeId);
    }
}
