using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface ICompanyDetailManager
    {
        Message AddOrEdit(CompanyDetail companyDetail);
        IEnumerable<CompanyDetail> GetAllCompanyDetail();
        Message Delete(int companyId);
        CompanyDetail GetACompanyDetail(int companyId);
    }
}
