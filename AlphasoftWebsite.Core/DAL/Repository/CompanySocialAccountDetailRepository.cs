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
    public class CompanySocialAccountDetailRepository : ICompanySocialAccountDetailRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public CompanySocialAccountDetailRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(CompanySocialAccountDetail companySocialAccountDetail)
        {
            if (companySocialAccountDetail.CompanySocialAccountDetailId == 0)
            {
                companySocialAccountDetail.CreatedDate = DateTime.Now;
                companySocialAccountDetail.UpdatedDate = DateTime.Now;
                companySocialAccountDetail.CreatedBy = 1;
                companySocialAccountDetail.UpdatedBy = 1;
                _dbContext.CompanySocialAccountDetails.Add(companySocialAccountDetail);
            }
            else
            {
                companySocialAccountDetail.UpdatedBy = 1;
                companySocialAccountDetail.UpdatedDate = DateTime.Now;
                _dbContext.Entry(companySocialAccountDetail).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int companySocialAccountDetailId)
        {
            var companySocialAccountDetail = _dbContext.CompanySocialAccountDetails.FirstOrDefault(x => x.CompanySocialAccountDetailId == companySocialAccountDetailId);
            if (companySocialAccountDetail != null)
            {
                _dbContext.CompanySocialAccountDetails.Remove(companySocialAccountDetail);
            }

            return _dbContext.SaveChanges();
        }     

        public IEnumerable<CompanySocialAccountDetail> GetAllCompanySocialAccountDetail()
        {

            var companySocialAccountDetail = _dbContext.CompanySocialAccountDetails.Include(a => a.CompanyDetail).Include(a => a.SocialAccountType).ToList();
            return companySocialAccountDetail;
        }

        public CompanySocialAccountDetail GetACompanySocialAccountDetail(int companySocialAccountDetailId)
        {
            var companySocialAccountDetail = _dbContext.CompanySocialAccountDetails.Include(a => a.CompanyDetail).Include(a => a.SocialAccountType).FirstOrDefault(x => x.CompanySocialAccountDetailId == companySocialAccountDetailId);
            return companySocialAccountDetail;
        }
    }
}
