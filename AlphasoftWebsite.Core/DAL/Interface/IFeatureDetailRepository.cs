using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
     public interface IFeatureDetailRepository
    {
        int AddOrEdit(FeatureDetail featureDetail);
        IEnumerable<FeatureDetail> GetAllFeatureDetail();
        int Delete(int featureDetailId);
        FeatureDetail GetAFeatureDetail(int featureDetailId);
    }
}
