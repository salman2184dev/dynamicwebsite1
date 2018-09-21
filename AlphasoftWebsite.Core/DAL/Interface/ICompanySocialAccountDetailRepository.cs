using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
   public interface ICompanySocialAccountDetailRepository
    {

        int AddOrEdit(CompanySocialAccountDetail companySocialAccountDetail);
        IEnumerable<CompanySocialAccountDetail> GetAllCompanySocialAccountDetail();
        int Delete(int companySocialAccountDetailId);
        CompanySocialAccountDetail GetACompanySocialAccountDetail(int companySocialAccountDetailId);
    }
}
