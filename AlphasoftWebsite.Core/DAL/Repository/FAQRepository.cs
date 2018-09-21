using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class FAQRepository : IFAQRepository
    {
        // GET: FAQ        
        public static AlphasoftWebsiteContext _dbContext;

        public FAQRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<FAQ> GetAllFAQs()
        {
            var FAQList = _dbContext.FAQs.ToList();
            return FAQList;
        }

        public int AddOrEdit(FAQ FAQ)
        {
            if (FAQ.FAQId == 0)
            {
                FAQ.CreatedDate = DateTime.Now;
                FAQ.UpdatedDate = DateTime.Now;
                FAQ.CreatedBy = 1;
                FAQ.UpdatedBy = 1;
                _dbContext.FAQs.Add(FAQ);
            }
            else
            {
                FAQ.UpdatedBy = 1;
                FAQ.UpdatedDate = DateTime.Now;
                _dbContext.Entry(FAQ).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int FAQId)
        {
            var FAQ = _dbContext.FAQs.FirstOrDefault(x => x.FAQId == FAQId);
            if (FAQ != null)
            {
                _dbContext.FAQs.Remove(FAQ);
            }

            return _dbContext.SaveChanges();
            ;
        }

        public FAQ GetAnFAQ(int FAQId)
        {
            var FAQ = _dbContext.FAQs.FirstOrDefault(x => x.FAQId == FAQId);
            return FAQ;
        }
    }
}