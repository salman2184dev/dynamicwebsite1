using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IFactorHeaderRepository
    {
        int AddOrEdit(FactorHeader factorHeader);
        IEnumerable<FactorHeader> GetAllFactorHeader();
        int Delete(int factorHeaderId);
        FactorHeader GetAFactorHeader(int factorHeaderId);
    }
}
