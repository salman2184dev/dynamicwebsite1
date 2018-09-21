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
    public class FAQHeaderRepository : IFAQHeaderRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public FAQHeaderRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(FAQHeader faqHeader)
        {
            if (faqHeader.FAQHeaderId == 0)
            {
                faqHeader.CreatedDate = DateTime.Now;
                faqHeader.UpdatedDate = DateTime.Now;
                faqHeader.CreatedBy = 1;
                faqHeader.UpdatedBy = 1;
                _dbContext.FAQHeaders.Add(faqHeader);
            }
            else
            {
                faqHeader.UpdatedBy = 1;
                faqHeader.UpdatedDate = DateTime.Now;
                _dbContext.Entry(faqHeader).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int FAQHeaderId)
        {
            var faqHeader = _dbContext.FAQHeaders.FirstOrDefault(x => x.FAQHeaderId == FAQHeaderId);
            if (faqHeader != null)
            {
                _dbContext.FAQHeaders.Remove(faqHeader);
            }

            return _dbContext.SaveChanges();
        }

        public FAQHeader GetAFAQHeader(int FAQHeaderId)
        {
            var faqHeader = _dbContext.FAQHeaders.FirstOrDefault(x => x.FAQHeaderId == FAQHeaderId);
            return faqHeader;
        }

        public IEnumerable<FAQHeader> GetAllFAQHeader()
        {
            var fawHeaderList = _dbContext.FAQHeaders.ToList();
            return fawHeaderList;
        }
    }
}
