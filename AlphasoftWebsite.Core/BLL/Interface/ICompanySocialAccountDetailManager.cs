using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface ICompanySocialAccountDetailManager
    {
        Message AddOrEdit(CompanySocialAccountDetail companySocialAccountDetail);
        IEnumerable<CompanySocialAccountDetail> GetAllCompanySocialAccountDetail();
        Message Delete(int companySocialAccountDetailId);
        CompanySocialAccountDetail GetACompanySocialAccountDetail(int companySocialAccountDetailId);
    }
}
