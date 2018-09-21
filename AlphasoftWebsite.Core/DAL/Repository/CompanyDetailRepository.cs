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
    public class CompanyDetailRepository : ICompanyDetailRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public CompanyDetailRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(CompanyDetail companyDetail)
        {
            if (companyDetail.CompanyId == 0)
            {
                companyDetail.CreatedDate = DateTime.Now;
                companyDetail.UpdatedDate = DateTime.Now;
                companyDetail.CreatedBy = 1;
                companyDetail.UpdatedBy = 1;
                _dbContext.CompanyDetails.Add(companyDetail);
            }
            else
            {
                companyDetail.UpdatedBy = 1;
                companyDetail.UpdatedDate = DateTime.Now;
                _dbContext.Entry(companyDetail).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int companyId)
        {
            var companyDetail = _dbContext.CompanyDetails.FirstOrDefault(x => x.CompanyId == companyId);
            if (companyDetail != null)
            {
                _dbContext.CompanyDetails.Remove(companyDetail);
            }

            return _dbContext.SaveChanges();
        }

        public CompanyDetail GetACompanyDetail(int companyId)
        {
            var companyDetail = _dbContext.CompanyDetails.FirstOrDefault(x => x.CompanyId == companyId);
            return companyDetail;
        }

        public IEnumerable<CompanyDetail> GetAllCompanyDetail()
        {
            var companyDetailList = _dbContext.CompanyDetails.ToList();
            return companyDetailList;
        }
    }
}
