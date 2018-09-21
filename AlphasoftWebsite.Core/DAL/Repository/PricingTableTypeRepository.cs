using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class PricingTableTypeRepository : IPricingTableTypeRepository
    {

        public static AlphasoftWebsiteContext _dbContext;

        public PricingTableTypeRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }


        public int AddOrEdit(PricingTableType pricingTableType)
        {
            if (pricingTableType.PricingTableTypeID == 0)
            {
                pricingTableType.CreatedDate = DateTime.Now;
                pricingTableType.UpdatedDate = DateTime.Now;
                pricingTableType.CreatedBy = 1;
                pricingTableType.UpdatedBy = 1;
                _dbContext.PricingTableTypes.Add(pricingTableType);
            }
            else
            {
                pricingTableType.UpdatedBy = 1;
                pricingTableType.UpdatedDate = DateTime.Now;
                _dbContext.Entry(pricingTableType).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int pricingTableTypeId)
        {
            var pricingTableType = _dbContext.PricingTableTypes.FirstOrDefault(x => x.PricingTableTypeID == pricingTableTypeId);
            if (pricingTableType != null)
            {
                _dbContext.PricingTableTypes.Remove(pricingTableType);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<PricingTableType> GetAllPricingTableType()
        {
            var pricingTableTypes = _dbContext.PricingTableTypes.ToList();
            return pricingTableTypes;
        }

        public PricingTableType GetAPricingTableType(int pricingTableTypeId)
        {
            var pricingTableType = _dbContext.PricingTableTypes.FirstOrDefault(x => x.PricingTableTypeID == pricingTableTypeId);
            return pricingTableType;
        }
    }
}
