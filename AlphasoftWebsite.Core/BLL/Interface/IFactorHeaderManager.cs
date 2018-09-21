using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IFactorHeaderManager
    {
        Message AddOrEdit(FactorHeader factorHeader);
        IEnumerable<FactorHeader> GetAllFactorHeader();
        Message Delete(int factorHeaderId);
        FactorHeader GetFactorHeader(int factorHeaderId);
    }
}
