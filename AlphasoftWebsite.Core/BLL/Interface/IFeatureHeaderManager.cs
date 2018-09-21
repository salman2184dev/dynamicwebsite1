using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
   public interface IFeatureHeaderManager
    {
        Message AddOrEdit(FeatureHeader featureHeader);
        IEnumerable<FeatureHeader> GetAllFeatureHeader();
        Message Delete(int featureHeaderId);
        FeatureHeader GetFeatureHeader(int featureHeaderId);
    }
}
