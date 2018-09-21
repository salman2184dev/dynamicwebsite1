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
    public class FeatureDetailRepository : IFeatureDetailRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public FeatureDetailRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddOrEdit(FeatureDetail featureDetail)
        {
            if (featureDetail.FeatureDetailId == 0)
            {
                featureDetail.CreatedDate = DateTime.Now;
                featureDetail.UpdatedDate = DateTime.Now;
                featureDetail.CreatedBy = 1;
                featureDetail.UpdatedBy = 1;
                _dbContext.FeatureDetails.Add(featureDetail);
            }
            else
            {
                featureDetail.UpdatedBy = 1;
                featureDetail.UpdatedDate = DateTime.Now;
                _dbContext.Entry(featureDetail).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int featureDetailId)
        {
            var featureDetail = _dbContext.FeatureDetails.FirstOrDefault(x => x.FeatureDetailId == featureDetailId);
            if (featureDetail != null)
            {
                _dbContext.FeatureDetails.Remove(featureDetail);
            }

            return _dbContext.SaveChanges();
        }

        public FeatureDetail GetAFeatureDetail(int featureDetailId)
        {
            var featureDetail = _dbContext.FeatureDetails.Include(a => a.IconList).FirstOrDefault(x => x.FeatureDetailId == featureDetailId);
            return featureDetail;
        }

        public IEnumerable<FeatureDetail> GetAllFeatureDetail()
        {
            var featureDetailList = _dbContext.FeatureDetails.Include(a => a.IconList).ToList();
            return featureDetailList;
        }
    }
}
