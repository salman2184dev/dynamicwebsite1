using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
   public interface IFactorDetailsRepository
    {
        int AddOrEdit(FactorDetail factorDetail);
        IEnumerable<FactorDetail> GetAllFactorDetail();
        int Delete(int factorDetailId);
        FactorDetail GetAFactorDetail(int factorDetailId);
    }
}
