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
    public class PricingRepository : IPricingRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public PricingRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(Pricing pricing)
        {
            if (pricing.PricingID == 0)
            {
                pricing.CreatedDate = DateTime.Now;
                pricing.UpdatedDate = DateTime.Now;
                pricing.CreatedBy = 1;
                pricing.UpdatedBy = 1;
                _dbContext.Pricings.Add(pricing);
            }
            else
            {
                pricing.UpdatedBy = 1;
                pricing.UpdatedDate = DateTime.Now;
                _dbContext.Entry(pricing).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }


        public int Delete(int pricingId)
        {
            var pricing = _dbContext.Pricings.FirstOrDefault(x => x.PricingID == pricingId);
            if (pricing != null)
            {
                _dbContext.Pricings.Remove(pricing);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<Pricing> GetAllPricing()
        {
            var pricings = _dbContext.Pricings.ToList();
            return pricings;
        }

        public Pricing GetAPricing(int pricingId)
        {
            var pricing = _dbContext.Pricings.FirstOrDefault(x => x.PricingID == pricingId);
            return pricing;
        }
    }
}
