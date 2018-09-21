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
    public class PricingDetailRepository : IPricingDetailRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public PricingDetailRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }


        public int AddOrEdit(PricingDetail pricingDetail)
        {

            if (pricingDetail.PricingDetailID == 0)
            {
                pricingDetail.CreatedDate = DateTime.Now;
                pricingDetail.UpdatedDate = DateTime.Now;
                pricingDetail.CreatedBy = 1;
                pricingDetail.UpdatedBy = 1;
                _dbContext.PricingDetails.Add(pricingDetail);
            }
            else
            {
                pricingDetail.UpdatedBy = 1;
                pricingDetail.UpdatedDate = DateTime.Now;
                _dbContext.Entry(pricingDetail).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int pricingDetailId)
        {
            var pricingDetail = _dbContext.PricingDetails.FirstOrDefault(x => x.PricingDetailID == pricingDetailId);
            if (pricingDetail != null)
            {
                _dbContext.PricingDetails.Remove(pricingDetail);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<PricingDetail> GetAllPricingDetail()
        {
            var pricingDetail = _dbContext.PricingDetails.Include(a => a.PricingDetailType).Include(a => a.PricingTableType).ToList();
            return pricingDetail;
        }

        public PricingDetail GetAPricingDetail(int pricingDetailId)
        {
            var pricingDetail = _dbContext.PricingDetails.Include(a => a.PricingDetailType).Include(a => a.PricingTableType).FirstOrDefault(x => x.PricingDetailID == pricingDetailId);
            return pricingDetail;
        }
    }
}
