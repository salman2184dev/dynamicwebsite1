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
    public class FeatureHeaderRepository : IFeatureHeaderRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public FeatureHeaderRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(FeatureHeader featureHeader)
        {
            if (featureHeader.FeatureHeaderId == 0)
            {
                featureHeader.CreatedDate = DateTime.Now;
                featureHeader.UpdatedDate = DateTime.Now;
                featureHeader.CreatedBy = 1;
                featureHeader.UpdatedBy = 1;
                _dbContext.FeatureHeaders.Add(featureHeader);
            }
            else
            {
                featureHeader.UpdatedBy = 1;
                featureHeader.UpdatedDate = DateTime.Now;
                _dbContext.Entry(featureHeader).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int featureHeaderId)
        {
            var featureHeader = _dbContext.FeatureHeaders.FirstOrDefault(x => x.FeatureHeaderId == featureHeaderId);
            if (featureHeader != null)
            {
                _dbContext.FeatureHeaders.Remove(featureHeader);
            }

            return _dbContext.SaveChanges();
        }

        public FeatureHeader GetAFeatureHeader(int featureHeaderId)
        {
            var featureHeader = _dbContext.FeatureHeaders.FirstOrDefault(x => x.FeatureHeaderId == featureHeaderId);
            return featureHeader;
        }

        public IEnumerable<FeatureHeader> GetAllFeatureHeader()
        {
            var featureHeaders = _dbContext.FeatureHeaders.ToList();
            return featureHeaders;
        }
    }
}
