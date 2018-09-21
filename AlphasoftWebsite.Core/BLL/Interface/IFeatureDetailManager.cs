using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
   public interface IFeatureDetailManager
    {
        Message AddOrEdit(FeatureDetail featureDetail);
        IEnumerable<FeatureDetail> GetAllFeatureDetail();
        Message Delete(int featureDetailId);
        FeatureDetail GetAFeatureDetail(int featureDetailId);
    }
}
