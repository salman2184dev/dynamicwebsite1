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
    public class FactorDetailsRepository : IFactorDetailsRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public FactorDetailsRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddOrEdit(FactorDetail factorDetail)
        {
            if (factorDetail.FactorDetailId == 0)
            {
                factorDetail.CreatedDate = DateTime.Now;
                factorDetail.UpdatedDate = DateTime.Now;
                factorDetail.CreatedBy = 1;
                factorDetail.UpdatedBy = 1;
                _dbContext.FactorDetails.Add(factorDetail);
            }
            else
            {
                factorDetail.UpdatedBy = 1;
                factorDetail.UpdatedDate = DateTime.Now;
                _dbContext.Entry(factorDetail).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int factorDetailId)
        {
            var factorDetail = _dbContext.FactorDetails.FirstOrDefault(x => x.FactorDetailId == factorDetailId);
            if (factorDetail != null)
            {
                _dbContext.FactorDetails.Remove(factorDetail);
            }

            return _dbContext.SaveChanges();
        }

        public FactorDetail GetAFactorDetail(int factorDetailId)
        {
            var factorDetail = _dbContext.FactorDetails.Include(a => a.IconList).FirstOrDefault(x => x.FactorDetailId == factorDetailId);
            return factorDetail;
        }

        public IEnumerable<FactorDetail> GetAllFactorDetail()
        {
            var factorDetailList = _dbContext.FactorDetails.Include(a => a.IconList).ToList();
            return factorDetailList;
        }
    }
}
