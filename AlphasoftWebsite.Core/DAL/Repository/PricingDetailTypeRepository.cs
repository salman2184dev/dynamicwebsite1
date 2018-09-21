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
    public class PricingDetailTypeRepository : IPricingDetailTypeRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public PricingDetailTypeRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }


        public int AddOrEdit(PricingDetailType pricingDetailType)
        {
            if (pricingDetailType.PricingDetailTypeID == 0)
            {
                pricingDetailType.CreatedDate = DateTime.Now;
                pricingDetailType.UpdatedDate = DateTime.Now;
                pricingDetailType.CreatedBy = 1;
                pricingDetailType.UpdatedBy = 1;
                _dbContext.PricingDetailTypes.Add(pricingDetailType);
            }
            else
            {
                pricingDetailType.UpdatedBy = 1;
                pricingDetailType.UpdatedDate = DateTime.Now;
                _dbContext.Entry(pricingDetailType).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int pricingDetailTypeId)
        {
            var pricingDetailType = _dbContext.PricingDetailTypes.FirstOrDefault(x => x.PricingDetailTypeID == pricingDetailTypeId);
            if (pricingDetailType != null)
            {
                _dbContext.PricingDetailTypes.Remove(pricingDetailType);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<PricingDetailType> GetAllPricingDetailType()
        {
            var pricingDetailType = _dbContext.PricingDetailTypes.ToList();
            return pricingDetailType;
        }

        public PricingDetailType GetAPricingDetailType(int pricingDetailTypeId)
        {
            var pricingDetailType = _dbContext.PricingDetailTypes.FirstOrDefault(x => x.PricingDetailTypeID == pricingDetailTypeId);
            return pricingDetailType;
        }
    }
}
