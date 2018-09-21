using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IFactorDetailManager

    {
        Message AddOrEdit(FactorDetail factorDetail);
        IEnumerable<FactorDetail> GetAllFactorDetail();
        Message Delete(int factorDetailId);
        FactorDetail GetAFactorDetail(int factorDetailId);
    }
}
