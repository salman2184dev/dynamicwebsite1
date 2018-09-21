using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface ICompanyDetailRepository
    {
        int AddOrEdit(CompanyDetail companyDetail);
        IEnumerable<CompanyDetail> GetAllCompanyDetail();
        int Delete(int companyId);
        CompanyDetail GetACompanyDetail(int companyId);
    }
}