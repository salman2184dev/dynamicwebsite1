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
    public class FactorHeaderRepository : IFactorHeaderRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public FactorHeaderRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(FactorHeader factorHeader)
        {
            if (factorHeader.FactorHeaderId == 0)
            {
                factorHeader.CreatedDate = DateTime.Now;
                factorHeader.UpdatedDate = DateTime.Now;
                factorHeader.CreatedBy = 1;
                factorHeader.UpdatedBy = 1;
                _dbContext.FactorHeaders.Add(factorHeader);
            }
            else
            {
                factorHeader.UpdatedBy = 1;
                factorHeader.UpdatedDate = DateTime.Now;
                _dbContext.Entry(factorHeader).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int factorHeaderId)
        {
            var factorHeader = _dbContext.FactorHeaders.FirstOrDefault(x => x.FactorHeaderId == factorHeaderId);
            if (factorHeader != null)
            {
                _dbContext.FactorHeaders.Remove(factorHeader);
            }

            return _dbContext.SaveChanges();
        }

        public FactorHeader GetAFactorHeader(int factorHeaderId)
        {
            var factorHeader = _dbContext.FactorHeaders.FirstOrDefault(x => x.FactorHeaderId == factorHeaderId);
            return factorHeader;
        }

        public IEnumerable<FactorHeader> GetAllFactorHeader()
        {
            var factorHeaders = _dbContext.FactorHeaders.ToList();
            return factorHeaders;
        }
    }
}
