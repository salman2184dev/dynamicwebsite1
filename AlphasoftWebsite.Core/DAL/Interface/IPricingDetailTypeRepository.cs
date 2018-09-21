using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IPricingDetailTypeRepository
    {
        int AddOrEdit(PricingDetailType pricingDetailType);
        IEnumerable<PricingDetailType> GetAllPricingDetailType();
        int Delete(int pricingDetailTypeId);
        PricingDetailType GetAPricingDetailType(int pricingDetailTypeId);
    }
}
